using System;
using System.IO;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.HighLevel.UI;
using System.Reflection;

namespace VitaUnit
{
	public static class Resources
	{
		public static ImageAsset GetImageAsset(string resourceId) {
			Assembly resourceAssembly = Assembly.GetCallingAssembly();
		    Stream fileStream = resourceAssembly.GetManifestResourceStream(resourceId);
			Byte[] dataBuffer = new Byte[fileStream.Length];
            fileStream.Read(dataBuffer, 0, dataBuffer.Length);
            Texture2D texture = new Texture2D(dataBuffer, false);
			return new ImageAsset(texture);
		}
	}
}

