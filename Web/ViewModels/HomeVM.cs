using Entities;

namespace Web.ViewModels
{
    public class HomeVM
    {
        public List<Slider> SliderList { get; set; }
        public List<Product> ProductList { get; set; }
        public List<Product> FeaturedProduct { get; set; }
        public List<Counter> Counters { get; set; }
        public AboutUs About { get; set; }
        public WhatWeDo WhatWeDo { get; set; }
        public WhyWeUs WhyWeUs { get; set; }
        public List<AboutUsText> AboutUsText { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
