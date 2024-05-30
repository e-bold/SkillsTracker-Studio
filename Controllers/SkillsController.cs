using System.ComponentModel.Design;
using System.Text;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

namespace SkillsTracker;

[Route("/skills")]
public class SkillsController : Controller
{
    Dictionary<string, string> progressOptions = new()
    {
        {"learningBasics", "Learning the basics"},
        {"buildingApps", "Building some apps"},
        {"expertCoder", "I am a professional developer!"}
    };



    //Endpoint: GET /skills
    [HttpGet("")]
    public IActionResult RenderSkillsPage()
    {
        string html = 
            "<h1>Skills tracker</h1>" + 
            "<h2>Coding Skills to Learn</h2>" +
            "<ol>" +
            "<li>C#</li>" +
            "<li>JavaScript</li>" +
            "<li>Python</li>" +
            "</ol>" +
            "<p>Click <a href ='/skills/form'> here</a> to update your learning progress. </p>";
        return Content(html, "text/html");
    }


    //Endpoint: GET /skills/forms
    [HttpGet("form")]
    public IActionResult RenderSkillsForm()
    {
        StringBuilder optionsHTML = new();
        foreach(KeyValuePair<string, string> option in progressOptions)
        {
            optionsHTML
                .Append("<option value='")
                .Append(option.Key)
                .Append("'>")
                .Append(option.Value)
                .Append("</option>");
        }


        string html = 
    "<form action='/skills/results' method='POST'>" + //bonus mission
    
    "<label>Date:</label>"+ "<br/>" +
        "<input type='date' name='specificdate'>" + "<br/>"+

    "<label>C# Progress: </label>" + "<br/>"+
      "<select name = 'csharp'>" + 
      optionsHTML + 
      "</select><br/>"+


    "<label>JavaScript: </label>" + "<br/>"+
      "<select name = 'java'>" + 
      optionsHTML +
      "</select><br/>" + 

    "<label for='python'>Python: </label>" + "<br/>"+
      "<select name = 'python'>"+ 
      optionsHTML +
      "</select><br/>" + 
       
      "<button type = 'submit'>Submit</button>" +
      "</form>";
        return Content(html, "text/html");
    }

    //Endpoint: POST /skills/form
    [HttpPost("form")]
    public IActionResult ProcessSkillsForm(string specificdate, string csharp, string java, string python)
    {
        string html = 
        "<h1>" + specificdate + "</h1>" +
        "<h3>My Progress</h3>" + 
        "<ol>" +
        "<li>C#: " + progressOptions[csharp] + "</li>" +
        "<li>JavaScript: " + progressOptions[java] + "</li>" +
        "<li>Python: " + progressOptions[python] + "</li>" +
        "</ol>";

        return Content(html, "text/html");
    }


    //Endpoint: POST /skills/form
    [HttpPost("results")]
    public IActionResult ProcessSkillsFormBonus(string specificdate, string csharp, string java, string python)
    {
        string html = 
        "<h1>" + specificdate + "</h1>" +
        "<h3>My Progress</h3>" +
        "<table>" +
            "<tr>" +
            "<td>C# </td>" +
            "<td>" + progressOptions[csharp] + "</td>" +
            "</tr>" +
            "<tr>" +
            "<td>JavaScript</td>" +
            "<td>" + progressOptions[java] + "</td>" +
            "</tr>" +
            "<tr>" +
            "<td>Python</td>" +
            "<td>" + progressOptions[python] + "</td>" +
            "</tr>" +
        "</table>";

        return Content(html, "text/html");
    }
}

