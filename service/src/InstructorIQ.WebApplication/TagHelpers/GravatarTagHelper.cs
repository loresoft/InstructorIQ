using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InstructorIQ.WebApplication.TagHelpers
{
    [HtmlTargetElement("gravatar", Attributes = "email")]
    public class GravatarTagHelper : TagHelper
    {
        [HtmlAttributeName("email")]
        public string Email { get; set; }

        [HtmlAttributeName("mode")]
        public Mode Mode { get; set; } = Mode.Mm;

        [HtmlAttributeName("rating")]
        public Rating Rating { get; set; } = Rating.g;

        [HtmlAttributeName("size")]
        public int Size { get; set; } = 50;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var email = Email
                .Trim()
                .ToLower();

            byte[] bytes;
            using (var md5 = MD5.Create())
                bytes = md5.ComputeHash(Encoding.ASCII.GetBytes(email));

            var hash = BitConverter
                .ToString(bytes)
                .Replace("-", "")
                .ToLower();

            var queryBuilder = new QueryBuilder();
            queryBuilder.Add("s", Size.ToString());
            queryBuilder.Add("d", GetModeValue(Mode));
            queryBuilder.Add("r", Rating.ToString());
            var queryString = queryBuilder.ToQueryString().ToString();

            var url = $"https://gravatar.com/avatar/{hash}";
            url = url + queryBuilder.ToQueryString();

            output.TagName = "img";
            output.Attributes.SetAttribute("src", url);
            output.Attributes.SetAttribute("alt", email);

        }

        private static string GetModeValue(Mode mode)
        {
            return mode == Mode.NotFound ? "404" : mode.ToString().ToLower();
        }
    }

    public enum Rating
    {
        g,
        pg,
        r,
        x
    }

    public enum Mode
    {
        [Display(Name = "404")]
        NotFound,
        [Display(Name = "Mm")]
        Mm,
        [Display(Name = "Identicon")]
        Identicon,
        [Display(Name = "Monsterid")]
        Monsterid,
        [Display(Name = "Wavatar")]
        Wavatar,
        [Display(Name = "Retro")]
        Retro,
        [Display(Name = "Blank")]
        Blank
    }
}
