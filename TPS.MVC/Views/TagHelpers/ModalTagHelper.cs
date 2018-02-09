using System.Reflection;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;


namespace TPS.MVC.Views.TagHelpers
{
    public class ModalTagHelper : TagHelper
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "modal fade");
            output.Attributes.Add("id", Id);
            output.Attributes.Add("role", "dialog");


            output.PreContent.SetHtmlContent("<div class=\"modal-dialog\">" +
                                             "<div class=\"modal-content\">" +
                                             "<div class=\"modal-header\">" +
                                             "<h4>" + Title + 
                                             "<button class=\"pull-right\" type=\"close\" data-dismiss=\"modal\">&times;</button>" +
                                             "</h4>" +
                                             "</div>" +
                                             "<div class=\"modal-body\">");

            output.PostContent.SetHtmlContent("</div>" +
                                              "</div>" +
                                              "</div>");
        }
    }
}
