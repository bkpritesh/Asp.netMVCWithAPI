using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Models
{
    public static class EnumExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectList(Enum enumValue)
        {
            return from Enum e in Enum.GetValues(enumValue.GetType())
                   select new SelectListItem
                   {
                       Selected = e.Equals(enumValue),
                       Text = e.ToDescription(),
                       Value = e.ToString()
                   };
        }

        public static string ToDescription(this Enum value)
        {
            var attributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static string ToDescription<T>(string value)
        {
            var attributes = (DescriptionAttribute[])value.GetType().GetField(value).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static IEnumerable<SelectListItem> GetTypes(string value)
        {
            var selectedItems = new List<SelectListItem>();

            selectedItems.Add(new SelectListItem
            {
                Text = "Pass",
                Value = "Pass",
                Selected = "Pass" == value
            });

            selectedItems.Add(new SelectListItem
            {
                Text = "Run",
                Value = "Run",
                Selected = "Run" == value
            });

            return selectedItems;
        }

        public static IEnumerable<SelectListItem> GetHash(string value)
        {
            var selectedItems = new List<SelectListItem>();

            selectedItems.Add(new SelectListItem
            {
                Text = "Left",
                Value = "Left",
                Selected = "Left" == value
            });

            selectedItems.Add(new SelectListItem
            {
                Text = "Right",
                Value = "Right",
                Selected = "Right" == value
            });

            selectedItems.Add(new SelectListItem
            {
                Text = "Middle",
                Value = "Middle",
                Selected = "Middle" == value
            });

            return selectedItems;
        }
    }
}