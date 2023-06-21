using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppTest.Models
{
    public class Pictures
    {
        public int Id { get; set; }
        public string Link { get; set; }

        public List<Pictures> Init()
        {
            List<Pictures> list_pic = new List<Pictures>();
            List<string> list = new List<string>()
            {
                "https://unsplash.it/200/200"
                , "https://unsplash.it/300/300"
                , "https://unsplash.it/400/400"
                , "https://unsplash.it/500/500"
                , "https://unsplash.it/600/600"
                , "https://unsplash.it/700/700"
                , "https://unsplash.it/800/800"
                , "https://unsplash.it/900/900"
            };
            int i = 0;
            foreach (var pic in list)
            {
                i++;
                list_pic.Add(new Pictures()
                {
                    Id = i,
                    Link = pic
                });
            }
            return list_pic;
        }
    }
}