using System.Drawing;
using System.Dynamic;
using System.Net;
using MoresCode;
using HTTPUtils;

#pragma warning disable CS8618
#pragma warning disable CS8625








Response rsp = await HttpUtils.instance.Get("https://crismo-morseassignment.web.val.run/msg");
Console.WriteLine(rsp.content);

Console.WriteLine(Translator.Translate(rsp.content));

// Create a mores code translator 



//---------------------
