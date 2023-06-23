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
                "https://images.unsplash.com/photo-1661956600684-97d3a4320e45?ixlib=rb-4.0.3&ixid=M3wxMjA3fDF8MHxzZWFyY2h8MXx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60"
                , "https://images.unsplash.com/photo-1575936123452-b67c3203c357?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60"
                , "https://images.unsplash.com/photo-1488372759477-a7f4aa078cb6?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60"
                , "https://images.unsplash.com/photo-1574169208507-84376144848b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60"
                , "https://images.unsplash.com/photo-1517329782449-810562a4ec2f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60"
                , "https://images.unsplash.com/photo-1661956602944-249bcd04b63f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDF8MHxzZWFyY2h8OHx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60"
                , "https://images.unsplash.com/photo-1613323593608-abc90fec84ff?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OXx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60"
                , "https://images.unsplash.com/photo-1598214886806-c87b84b7078b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTV8fGltYWdlfGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60"
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