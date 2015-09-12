﻿using System;
using System.ComponentModel;
using System.IO;
using J6.Cms.Cache;
using J6.Cms.Conf;
using J6.Cms.Domain.Interface.Common.Language;
using J6.Cms.Infrastructure;

namespace J6.Cms.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class CmsLanguagePackage
    {
        private static LanguagePackage _lang;
        private static CmsLanguagePackage _instance;


        internal static CmsLanguagePackage Create()
        {
            return _instance ?? (_instance = new CmsLanguagePackage());
        }

        private CmsLanguagePackage()
        {
            _lang = new LanguagePackage();
            _lang.LoadFromXml(ResourceMap.XmlLangPackage);
            LoadLocaleXml();

            /*
           IDictionary<Languages,String> dict = new Dictionary<Languages,String>();

           //标签
           dict.Add(Languages.Zh_CN,"无标签");
           dict.Add(Languages.Zh_TW,"无标签");
           dict.Add(Languages.En_US,"no tags");

           lang.Add(LanguagePackageKey.PAGE_NO_TAGS, dict);

           dict.Clear();
            const string zh_cn_pack = "上一页|下一页|{0}|选择页码：{0}页";
           const string zh_tw_pack = "上一頁|下一頁|{0}|選擇頁碼：{0}頁";
           const string en_us_pack = "Previous|Next|{0}|Select Page：{0}";


           dict.Add(Languages.Zh_CN, "上一页");
           */
        }


        /// <summary>
        /// 加载系统内置的语言配置文件
        /// </summary>
        private void LoadLocaleXml()
        {
            DirectoryInfo dir = new DirectoryInfo(Cms.PyhicPath + CmsVariables.FRAMEWORK_PATH + "locale");
            if (dir.Exists)
            {
                FileInfo[] files = dir.GetFiles("*.xml");
                Languages lang;
                foreach (var fileInfo in files)
                {
                    bool result = Enum.TryParse(fileInfo.Name.Substring(0, fileInfo.Name.IndexOf(".", StringComparison.Ordinal)), true, out lang);
                    if (result)
                    {
                        _lang.LoadStandXml(lang, fileInfo.FullName);
                    }
                }
            }
        }


        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public String Get(LanguagePackageKey key)
        {
            return _lang.Get(Cms.Context.CurrentSite.Language, key);
        }

        public string Get(Languages language, string key)
        {
            return _lang.GetValueByKey(language, key);
        }
    }
}
