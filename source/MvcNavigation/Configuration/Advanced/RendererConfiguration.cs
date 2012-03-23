// # Copyright � 2012, Arnold Zokas
// # All rights reserved. 

using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MvcNavigation.Internal;

namespace MvcNavigation.Configuration.Advanced
{
	public static class RendererConfiguration
	{
		static RendererConfiguration()
		{
			MenuRenderer = (html, model, maxLevels, renderAllLevels) =>
			{
				var modelHtmlHelper = new HtmlHelper<INode>(html.ViewContext, new ViewDataContainer<INode>(model));
				return modelHtmlHelper.DisplayFor(node => node,
				                                  "MvcNavigationMenuRoot",
				                                  new
				                                  {
				                                  	CurrentLevel = 1,
				                                  	MaxLevels = maxLevels,
				                                  	RenderAllLevels = renderAllLevels
				                                  });
			};
		}

		public static Func<HtmlHelper, INode, int, bool, MvcHtmlString> MenuRenderer { get; set; }
	}
}