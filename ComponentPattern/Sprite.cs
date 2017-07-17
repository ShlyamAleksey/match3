using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Lizzard.str;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Lizzard.ComponentPattern
{
    public class Sprite : Composite
    {
        protected Texture2D texture;
        public Sprite parent;

        public float sizeX = 0;
        public float sizeY = 0;
        public Color tint = Color.White;

        protected Rectangle _sourceRect;
		protected Vector2 _pivot = new Vector2(0, 0);
        protected Vector2 _drawPosition;

        protected float _x = 0f;
        protected float _y = 0f;
        protected float _rotation = 0f;
        protected float _scaleX = 1.0f;
		protected float _scaleY = 1.0f;
        protected float _alpha = 1f;
        protected bool _mouseEnable = true;

        protected float _globalScaleX = 1.0f;
        protected float _globalScaleY = 1.0f;
        protected float _globalAlpha = 1.0f;
        protected bool _globalMouseEnable = true;
 
        protected bool _visible = true;
        protected bool _clickStatus = false;
        public bool bubble { get; private set; } = true;

        public int width { get; set; } //оригинальная ширина и высота зависит от масштаба самого спрайта без учета родителя
        public int height { get; set; }

        public float globalScaleX { get; private set; } 
        public float globalScaleY { get; private set; }

        public Vector2 drawPosition { get; private set; }

        public Rectangle bounce = new Rectangle();

        public Sprite(string atlasName = "") : base("instance")
		{
			this.texture = TextureManager.textureByName(atlasName);
            if (texture != null) _sourceRect = new Rectangle(0, 0, texture.Width, texture.Height);
            updateBounce();
        }

		public Sprite(string atlasName, string sourceRec) : base("instance")
		{
		    this.bubble = true;
			this.texture = TextureManager.textureByName(atlasName);
			_sourceRect = XmlAssetsParser.rectangle(sourceRec);
            updateBounce();
        }

        virtual public void draw()
        {    
            if(_visible && parent != null)
			{
                if (texture != null) MainApp.spriteBatch.Draw(this.texture, _drawPosition, _sourceRect, tint * _globalAlpha, _rotation + parent.rotation, _pivot,
                                                                new Vector2(_globalScaleX, _globalScaleY), SpriteEffects.None, 0.0f);
                foreach (Sprite child in this.children) { child.draw();  }
            }          
        }

        private void getGlobalProperties()
        {
            Sprite target = this;
            float tempScaleX = 1f;
            float tempScaleY = 1f;

            float tempAlpha = 1f;
            long tempMouseEnable = 1;

            while (target.parent != null)
            {
                tempScaleX = tempScaleX * target.scaleX;
                tempScaleY = tempScaleY * target.scaleY;
                tempAlpha = tempAlpha * target.alpha;
                tempMouseEnable = tempMouseEnable * (target._mouseEnable ? 1 : 0);
                target = target.parent;
            }

            globalScaleX = _globalScaleX = tempScaleX;
            globalScaleY = _globalScaleY = tempScaleY;
            _globalAlpha = tempAlpha;
            _globalMouseEnable = tempMouseEnable == 1;
        }

        virtual public void update() {

            dispatchEvent(new Event(Event.ENTER_FRAME));

            List<Component> tempChildren = ListUtils.cloneList<Component>(this.children);
            foreach (Sprite child in tempChildren) { child.update(); }

            MouseState state = Mouse.GetState();
            onMouseDown(state);
            onMouseClick(state);
            onMouseMove(state);
        }

        public void addChild(Sprite child) {

            if (child == null) throw new Exception("Child can not be NULL");
            base.addChild(child);
            child.parent = this;
            updateBounce();
        }

        

        //Set X
        public float x
        {
            set { _x = value; updateBounce(); }
            get { return _x; }
        }

        //Set Y
        public float y
        {
            set { _y = value; updateBounce(); }
            get { return _y; }
        }

        //Set Rotation
        public float rotation
        {
            set { _rotation = value; updateBounce(); }
            get { return _rotation; }
        }

        //Set ScaleX
        public float scaleX
        {
            set { _scaleX = value; updateBounce(); }
            get { return _scaleX; }
        }

		//Set ScaleY
		public float scaleY
		{
			set { _scaleY = value; updateBounce(); }
			get { return _scaleY; }
		}

		//Set Pivot
		public Vector2 pivot
		{
			set { _pivot = new Vector2( value.X / scaleX, value.Y / scaleY); updateBounce(); }
			get { return new Vector2(_pivot.X*scaleX, _pivot.Y * scaleY); }
		}

        //Set Visible
        public bool visible
        {
            set
            {
                _visible = value;
                foreach (Sprite child in this.children) { child.visible = value; }
            }
            get { return _visible; }
        }

        //Set Visible
        public bool mouseEnable
        {
            set { _mouseEnable = value; updateBounce(); }
            get { return _mouseEnable; }
        }

        //Set alpha
        public float alpha
        {
            set { _alpha = value; updateBounce(); }
            get { return _alpha; }
        }

        public Sprite getChild(int index) 
		{
			return children[index] as Sprite;
		}

		public Sprite getChild(String name)
		{
			foreach (Sprite child in children)
			{
				if(child.name == name) return child as Sprite;
			}
			return null;
		}

        virtual protected void onMouseClick(MouseState state)
        {
            if (state.LeftButton.ToString() == "Released")
            {
                if (bounce.Contains(state.Position))
                {
                    if (_clickStatus)
                    { 
                        dispathClick(MouseEvent.HASH);
                        _clickStatus = false;
                    }
                }
                else _clickStatus = false;
            }
        }

        public void dispathClick(int mouseHash)
        {
            if (_globalMouseEnable && bubble && visible)
            {
                //Debug.WriteLine(mouseHash + " " + this.GetType().ToString());
                dispatchEvent(new MouseEvent(MouseEvent.CLICK));
                this.bubble = false;
            }

            if (parent != null)
            {
                parent.dispathClick(mouseHash);
            }   
        }

        virtual protected void onMouseDown(MouseState state)
        {
            if (state.LeftButton.ToString() == "Pressed" && bounce.Contains(state.Position))
            {
                dispatchEvent(new MouseEvent(MouseEvent.LEFT_DOWN));
                _clickStatus = true;
            }
        }

        //Worsk only with rotation 0, 180
        private void onMouseMove(MouseState state)
        { 
            if (state.LeftButton.ToString() == "Released" && bounce.Contains(state.Position))
            {
                dispatchEvent(new MouseEvent(MouseEvent.MOVE));
            }       
        }


        public void setMouseBubbling(bool bubble)
        {
            List<Component> tempChildren = ListUtils.cloneList<Component>(this.children);
            this.bubble = bubble;
            foreach (Sprite spr in tempChildren)
            {
                spr.setMouseBubbling(bubble);
            }
        }

        protected void updateBounce()
        {
            getGlobalProperties();
            width = (int)((float)_sourceRect.Width*scaleX);
            height = (int)((float)_sourceRect.Height * scaleY);

            bounce.Width = (int)(_sourceRect.Width * _globalScaleX);
            bounce.Height = (int)(_sourceRect.Height * _globalScaleY);

            if (parent != null)
            {
                // _drawPosition = new Vector2(parent.x * parent.globalScaleX + (float)Math.Cos(parent.rotation) * _x * parent.globalScaleX - (float)Math.Cos(Math.PI / 2 - parent.rotation) * _y * parent.globalScaleY, parent.y * parent.globalScaleY + (float)Math.Sin(parent.rotation) * _x * parent.globalScaleX + (float)Math.Sin(Math.PI / 2 - parent.rotation) * _y * parent.globalScaleY);
                drawPosition = _drawPosition = new Vector2( parent.drawPosition.X + _x * parent.globalScaleX,
                                                            parent.drawPosition.Y + _y * parent.globalScaleY);
                bounce.X = (Int32)(_drawPosition.X - _pivot.X * _globalScaleX);
                bounce.Y = (Int32)(_drawPosition.Y - _pivot.Y * _globalScaleY);
            }
            foreach (Sprite child in this.children) { child.updateBounce(); }
        }
    }
}
