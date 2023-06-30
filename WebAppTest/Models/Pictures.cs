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
                "http://unsplash.it/1200/800?image=940"
                , "http://unsplash.it/1280/900?image=906"
                , "http://unsplash.it/1100/840?image=885"
                , "http://unsplash.it/1300/900?image=823"
                , "http://unsplash.it/1200/700?image=815"
                , "http://unsplash.it/1120/1000?image=677"
                , "http://unsplash.it/1340/820?image=401"
                , "http://unsplash.it/1240/680?image=623"
                , "http://unsplash.it/1580/780?image=339"
                , "http://unsplash.it/1200/800?image=940"
                , "http://unsplash.it/1280/900?image=906"
                , "http://unsplash.it/1100/840?image=885"
                , "http://unsplash.it/1300/900?image=823"
                , "http://unsplash.it/1200/700?image=815"
                , "http://unsplash.it/1120/1000?image=677"
                , "http://unsplash.it/1340/820?image=401"
                , "http://unsplash.it/1240/680?image=623"
                , "http://unsplash.it/1580/780?image=339"
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