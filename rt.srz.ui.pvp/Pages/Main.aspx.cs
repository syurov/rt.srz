﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI;
using StructureMap;
using rt.srz.model.interfaces.service;
using rt.srz.ui.pvp.Controllers;
using System.Text;
using rt.srz.model.srz;

using NHibernate;

namespace rt.srz.ui.pvp.Pages
{
    public partial class Main : Page
    {
      /// <summary>
      /// Обслуживает Intellisense для ввода имени
      /// </summary>
      /// <param name="prefixText"></param>
      /// <param name="count"></param>
      /// <param name="contextKey"></param>
      /// <returns></returns>
      [System.Web.Services.WebMethod]
      public static List<string> GetFirstNameAutoComplete(string prefixText, int count)
      {
        return IntellisenseController.GetFirstNameAutoComplete(prefixText, count);
      }

      /// <summary>
      /// Обслуживает Intellisense для ввода отчества
      /// </summary>
      /// <param name="prefixText">
      /// The prefix Text.
      /// </param>
      /// <param name="count">
      /// The count.
      /// </param>
      /// <param name="contextKey">
      /// The context Key.
      /// </param>
      /// <returns>
      /// The <see cref="List"/>.
      /// </returns>
      [System.Web.Services.WebMethod]
      public static List<string> GetMiddleNameAutoComplete(string prefixText, int count, string contextKey)
      {
        return IntellisenseController.GetMiddleNameAutoComplete(prefixText, count, contextKey);
      }

      /// <summary>
      /// Возвращает название ТФОМС по ОГРН
      /// </summary>
      /// <param name="okato">
      /// The okato.
      /// </param>
      /// <param name="ogrn">
      /// The ogrn.
      /// </param>
      /// <returns>
      /// The <see cref="string"/>.
      /// </returns>
      [System.Web.Services.WebMethod]
      public static string GetTfomsAndSmoNames(string okato, string ogrn)
      {
        var regulatoryService = ObjectFactory.GetInstance<IRegulatoryService>();
        var tfoms = regulatoryService.GetTfomsByOkato(okato);
        var smo = regulatoryService.GetSmoByOkatoAndOgrn(okato, ogrn);
        if (tfoms != null && smo != null)
        {
          return string.Format("{0};{1}", tfoms.ShortName, smo.ShortName);
        }
        
        return string.Empty;
      }

      /// <summary>
      /// Возвращает название ТФОМС по ОГРН
      /// </summary>
      /// <param name="startDate"> </param>
      /// <param name="endDate"> </param>
      /// <param name="ogrn"></param>
      /// <returns></returns>
      [System.Web.Services.WebMethod]
      public static IList<string> GetErrors(string startDate, string endDate)
      {
        DateTime start;
        DateTime end;
        if (!DateTime.TryParse(startDate, out start) || !DateTime.TryParse(endDate, out end))
        {
          return null;
        }
        var service = ObjectFactory.GetInstance<IStatementService>();

        return service.GetErrorsByPeriod(start, end);
      }
    }
}