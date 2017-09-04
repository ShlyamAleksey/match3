using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Xml;

namespace Lizzard.str
{
	class XmlAssetsParser
	{
		private XmlDocument document = new XmlDocument();
		static private List<AssetData> assetsConfig = new List<AssetData>();

		public void load(string path)
		{
			document.Load(path);

			foreach (XmlNode node in document.DocumentElement)
			{
				AssetData data = new AssetData();

				data.name = node.Attributes[0].Value;
				data.rectangle.X = Convert.ToInt32(node.Attributes[1].Value);
				data.rectangle.Y = Convert.ToInt32(node.Attributes[2].Value);
				data.rectangle.Width = Convert.ToInt32(node.Attributes[3].Value);
				data.rectangle.Height = Convert.ToInt32(node.Attributes[4].Value);

				assetsConfig.Add(data);
			}
		}

		static public Rectangle rectangle(string name)
		{
			foreach (AssetData item in assetsConfig)
			{
				if (item.name == name)
				{
					return item.rectangle;
				}
			}
			throw new Exception("Texture with name " + name + " has not been found");
		}

		static public bool hasRectangle(string name)
		{
			foreach (AssetData item in assetsConfig)
			{
				if (item.name == name)
				{
					return true;
				}
			}
			return false;
		}
	}

	public struct AssetData
	{
		public Rectangle rectangle;
		public string name;
	}
}
