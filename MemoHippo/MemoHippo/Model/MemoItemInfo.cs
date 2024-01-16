﻿using System;
using System.Collections.Generic;
using System.IO;

namespace MemoHippo.Model
{
    public class MemoItemInfo
    {
        public int Id { get; set; } //同文件存储路径
        public int Type { get; set; } //0 默认，1 背单词
        public string Title { get; set; }
        public string Tag { get; set; }
        public string Icon { get; set; }
        public string Parm { get; set; } //额外数据

        public void SetParm(string key, string v)
        {
            if (Parm == null)
                Parm = "";
            List<string> infos = new List<string>();
            var items = Parm.Split('|');
            foreach(var item in items)
            {
                if (string.IsNullOrEmpty(item))
                    continue;
                var isMatch = item.StartsWith(key);
                if (!isMatch)
                    infos.Add(item);
            }
            if (v != "0")
                infos.Add(string.Format("{0}:{1}", key, v));
            Parm = string.Join("|", infos);
        }

        public List<Tuple<string, string>> GetParmList()
        {
            List<Tuple<string, string>> results = new List<Tuple<string, string>>();
            if (string.IsNullOrEmpty(Parm))
                return results;

            var items = Parm.Split('|');
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item))
                    continue;
                var itInfo = item.Split(':');
                results.Add(new Tuple<string, string>(itInfo[0], itInfo[1]));
            }
            return results;
        }

        public DateTime GetCreateTime()
        {
            return new FileInfo(string.Format("{0}/{1}.rtf", ENV.SaveDir, Id)).CreationTime;
        }
        public DateTime GetModifyTime()
        {
            return new FileInfo(string.Format("{0}/{1}.rtf", ENV.SaveDir, Id)).LastWriteTime;
        }

        public void AddTag(string s)
        {
            if (Tag != null && Tag.Contains(s))
                return;
            if (Tag == null || Tag.Length == 0)
                Tag = s;
            else
                Tag += "," + s;
        }

        public bool HasTag(string s)
        {
            if (Tag == null)
                return false;
            return Tag.Contains(s);
        }
    }
}