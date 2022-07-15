List<Phone> phones = new List<Phone>()
{
        new Phone("https://files.foxtrot.com.ua/PhotoNew/img_0_60_8653_0_1_637883262083112243.webp", "XIAOMI Redmi 10C 4/128Gb Graphite Gray", 7300),

    new Phone("https://files.foxtrot.com.ua/PhotoNew/img_0_60_8648_0_1_637880480777973297.webp", "APPLE iPhone 13 128GB Blue DEMO", 32000),
    new Phone("https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcQK4JqYtn84tdPX1zjeJcz442uBblrlo0nzGdX7zEK8FuGVyt2kspIIZelM9X3mluQS3BwFNLhaGWA&usqp=CAc", "APPLE iPhone 11 64GB Purple без адаптера)", 21000),
    new Phone("https://files.foxtrot.com.ua/PhotoNew/img_0_60_8242_0_1.webp", "APPLE iPhone 13 Pro Max 512GB Gold ", 60000),
    new Phone("https://files.foxtrot.com.ua/PhotoNew/img_0_60_8271_0_1.webp", "APPLE iPhone 13 Mini 256GB RED", 31000),
    new Phone("https://files.foxtrot.com.ua/PhotoNew/img_0_60_7840_8.webp", "SAMSUNG Galaxy S21 Ultra 12/128 Gb Dual Sim Phantom Black", 35500),
    new Phone("https://files.foxtrot.com.ua/PhotoNew/img_0_60_7894_0.webp", "SAMSUNG Galaxy A52 8/256 Duos Light Violet", 15500),
    new Phone("https://files.foxtrot.com.ua/PhotoNew/img_0_60_8128_0.webp", "SAMSUNG Galaxy M32 6/128 Gb Dual Sim Black", 10000),
    new Phone("https://i.citrus.world/imgcache/size_800/uploads/shop/7/c/7c3c45d0122895b17ac6b6acd813582f.jpg", "Samsung Galaxy Flip 3 F711B 2021 8/256GB Lavender", 25000),
    new Phone("https://files.foxtrot.com.ua/PhotoNew/img_0_60_8317_10_1.webp", "XIAOMI 11T Pro 8/128GB Celestial Blue", 19000),
    new Phone("https://files.foxtrot.com.ua/PhotoNew/img_0_60_8526_0_1_637786387078349769.webp", "XIAOMI Redmi Note 11 4/128 GB Dual Sim Graphite Gray", 9000),
    new Phone("https://files.foxtrot.com.ua/PhotoNew/img_0_60_8695_0_1_637896771955788432.webp", "XIAOMI Redmi 9A 2/32GB Glacial Blue", 4400)
};
List<Phone> phoness = new List<Phone>();
List<Account> accounts = new List<Account>()
{
    new Account("vv", "12345678", true),
    new Account("nikitacsk", "11111111", false),
    new Account("Raifurua", "k8888888", true),
    new Account("Rich_Minion", "banana", false)

};
string HTML = @"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf - 8' />
      <title> TechnoМикита </title>
  </head>
  <body>
  
      <h1 style = 'color:#0000ff' > Магазин телефонов </h1>
       
           <a href = 'https://localhost:7111' marg> Головна </a><br/>
           
               <a href = 'https://localhost:7111/search'> Пошук </a><br/>
            
                
    <a href='https://localhost:7111/login'>Вхід</a><br />
    <a href='https://localhost:7111/admin'>Admin Panel</a><br />
    <h2>Виберіть тип сортироки товарів</h2>
    <form method='post' action='postcatalog'>
        <p>
            Type:<br/>
            <select multiple name = 'type'>
 
                 <option> Від A до Z</option>
                <option>Від Z до A</option>
                <option>За ціною дорожче</option>
                <option>За ціною дешевше</option>
            </select>
        </p>
        <input type='submit' value='Send'/>
    </form>";
string HTMLS = @"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf - 8' />
      <title> TechnoМикита </title>
  </head>
  <body>
  
      <h1 style = 'color:#0000ff' > Магазин телефонов </h1>
       
           <a href = 'https://localhost:7111' marg> Головна </a><br/>
           
               <a href = 'https://localhost:7111/search'> Пошук </a><br/>
            
    <a href='https://localhost:7111/login'>Вхід</a><br />
    <a href='https://localhost:7111/admin'>Admin Panel</a><br />
    <form method='post' action='postadmindel'>
        <p>
            Виберіть товар:<br/>
            <select multiple name = 'name'>";
string HTMLT = @"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf - 8' />
      <title> TechnoМикита </title>
  </head>
  <body>
  
      <h1 style = 'color:#0000ff' > Магазин телефонов </h1>
       
           <a href = 'https://localhost:7111' marg> Головна </a><br/>
           
               <a href = 'https://localhost:7111/search'> Пошук </a><br/>
            
    <a href='https://localhost:7111/login'>Вхід</a><br />
    <a href='https://localhost:7111/admin'>Admin Panel</a><br />
    <form method='post' action='postadminch'>
        <p>
            Виберіть товар:<br/>
            <select multiple name = 'name'>";

bool IsAdmin = false;
string TYPE;
int index;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();
app.Map("/login", async appBuilder =>
{
    appBuilder.Run(async context =>
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.SendFileAsync("html/login.html");
    });
});
app.Map("/postlogin", async appBuilder =>
{
    appBuilder.Run(async context =>
    {
        
        int res = 0;
        var form = context.Request.Form;
        string name = form["name"];
        string pas = form["pas"];
        for (int i=0; i<accounts.Count; i++)
        {
            if(name == accounts[i].login && pas == accounts[i].password)
            {
                res = 1;
                IsAdmin = accounts[i].IsAdmin;
                i = accounts.Count;
            }
        }
        if(res == 0)
        {
            context.Response.Redirect("/login");
        }
        else
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("html/loginaccess.html");
        }
    });
});

app.Map("/reg", async appBuilder =>
{
    appBuilder.Run(async context =>
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.SendFileAsync("html/reg.html");
    });
});
app.Map("/postreg", async appBuilder =>
{
    appBuilder.Run(async context =>
    {
        var form = context.Request.Form;
        string name = form["name"];
        string pas = form["pas"];
        accounts.Add(new Account(name, pas, false));
        context.Response.Redirect("/");
    });
});

app.Map("/search", async appBuilder =>
{
    appBuilder.Run(async context =>
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.SendFileAsync("html/search.html");
    });
});
app.Map("/postcatalog", async appBuilder =>
{
    appBuilder.Run(async context =>
    {
        var form = context.Request.Form;
        string type = form["type"];
        string name = form["name"];
        string html = HTML;

        if (name != null)
        {
            phoness = new List<Phone>();
            search(phones, phoness, name);
            context.Response.ContentType = "text/html; charset=utf-8";
            for (int i = 0; i < phoness.Count; i++)
            {
                html = html + @"<img src='" + phoness[i].picture + @"' height='100px'/>";
                html = html + "\n";
                html = html + @"<big>" + phoness[i].name + @".  Ціна:" + phoness[i].price + "грн." + @"</big><br/>";
                html = html + "\n";
            }
            await context.Response.WriteAsync(html);
            Console.WriteLine(html);
        }
        else if (type == "За ціною дешевше")
        {
            
            sort_e_ch(phoness);
            context.Response.ContentType = "text/html; charset=utf-8";
            for (int i = 0; i < phoness.Count; i++)
            {
                html = html + @"<img src='" + phoness[i].picture + @"' height='100px'/>";
                html = html + "\n";
                html = html + @"<big>" + phoness[i].name + @".  Ціна:" + phoness[i].price + "грн." + @"</big><br/>";
                html = html + "\n";
            }
            await context.Response.WriteAsync(html);

        }
        else if(type == "За ціною дорожче")
        {
            
            sort_ch_e(phoness);
            context.Response.ContentType = "text/html; charset=utf-8";
            for (int i = 0; i < phoness.Count; i++)
            {
                html = html + @"<img src='" + phoness[i].picture + @"' height='100px'/>";
                html = html + "\n";
                html = html + @"<big>" + phoness[i].name + @".  Ціна:" + phoness[i].price + "грн." + @"</big><br/>";
                html = html + "\n";
            }
            await context.Response.WriteAsync(html);
        }
        else if(type == "Від A до Z")
        {
            
            sort_a_z(phoness);
            context.Response.ContentType = "text/html; charset=utf-8";
            for (int i = 0; i < phoness.Count; i++)
            {
                html = html + @"<img src='" + phoness[i].picture + @"' height='100px'/>";
                html = html + "\n";
                html = html + @"<big>" + phoness[i].name + @".  Ціна:" + phoness[i].price + "грн." + @"</big><br/>";
                html = html + "\n";
            }
            await context.Response.WriteAsync(html);
        }
        else if(type == "Від Z до A")
        {
            
            sort_z_a(phoness);
            context.Response.ContentType = "text/html; charset=utf-8";
            for (int i = 0; i < phoness.Count; i++)
            {
                html = html + @"<img src='" + phoness[i].picture + @"' height='100px'/>";
                html = html + "\n";
                html = html + @"<big>" + phoness[i].name + @".  Ціна:" + phoness[i].price+"грн." + @"</big><br/>";
                html = html + "\n";
            }
            await context.Response.WriteAsync(html);
            Console.WriteLine(html);
        }
        
    });
});

app.Map("/admin", async appBuilder =>
{
    appBuilder.Run(async context =>
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        if (IsAdmin == false)
        {
            await context.Response.SendFileAsync("html/adminfaild.html");
        }
        else
        {
            await context.Response.SendFileAsync("html/adminaccess.html");
        }
    });
});

app.Map("/postadmin", async appBuilder =>
{
    appBuilder.Run(async context =>
    {
        var form = context.Request.Form;
        string type = form["type"];
        string name = form["name"];
        string html = HTMLS;
        if (type == "Додати товар")
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("html/adminadd.html");
        }
        else if(type == "Видалити товар")
        {
            for(int i=0; i<phones.Count; i++)
            {
                html += @"<option>" + phones[i].name + @"</option>" + "\n";
            }
            html += @"</select>" + "\n" + @"</p>" + "\n" + @"<input type='submit' value='Send'/>" + "\n" + @"</form>";
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync(html);

        }
        else
        {
            html = HTMLT;
            for (int i = 0; i < phones.Count; i++)
            {
                html += @"<option>" + phones[i].name + @"</option>" + "\n";
            }
            html += @"</select>" + "\n" + @"</p>" + "\n" + @"<input type='submit' value='Send'/>" + "\n" + @"</form>";
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync(html);
        }
    });
});

app.Map("/postadmindel", async appBuilder =>
{
    appBuilder.Run(async context =>
    {
        var form = context.Request.Form;
        string name = form["name"];
        for(int i=0; i<phones.Count; i++)
        {
            if(name == phones[i].name)
            {
                phones.RemoveAt(i);
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.SendFileAsync("html/admindel.html");
            }
        }
    });
});

app.Map("/postadminch", async appBuilder =>
{
    appBuilder.Run(async context =>
    {
        var form = context.Request.Form;
        string name = form["name"];
        for (int i = 0; i < phones.Count; i++)
        {
            if (name == phones[i].name)
            {
                phones.RemoveAt(i);
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.SendFileAsync("html/adminadd.html");
            }
        }
    });
});

app.Map("/postadminadd", async appBuilder =>
{
    appBuilder.Run(async context =>
    {
        var form = context.Request.Form;
        string name = form["name"];
        string cost = form["cost"];
        string pic = form["pic"];
        double pr=0;
        for(int i=cost.Length-1; i>=0; i--)
        {
            pr += (cost[i]-48)* Math.Pow(10, cost.Length-i-1);
        }
        phones.Add(new Phone(pic, name, pr));
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.SendFileAsync("html/adminaddaccess.html");
    });
});

app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("html/main.html");
});


app.Run();

void sort_e_ch(List<Phone> l)
{
    Phone n = new Phone();
    for(int i = 0; i < l.Count ; i++)
    {
        for(int j = 0; j < (l.Count-1); j++)
        {
            if(l[j].price > l[j + 1].price)
            {
                n = l[j + 1];
                l[j + 1] = l[j];
                l[j] = n;
            }
        }
    }
}

void sort_ch_e(List<Phone> l)
{
    Phone n = new Phone();
    for (int i = 0; i < l.Count; i++)
    {
        for (int j = 0; j < (l.Count - 1); j++)
        {
            if (l[j].price < l[j + 1].price)
            {
                n = l[j + 1];
                l[j + 1] = l[j];
                l[j] = n;
            }
        }
    }

}

void sort_a_z(List<Phone> l)
{
    Phone n = new Phone();
    int res = 0;
    for(int i=0; i < l.Count; i++)
    {
        for(int j=0; j < (l.Count - 1); j++)
        {
            res = 0;
            if(l[j].name.Length < l[j + 1].name.Length)
            {
                for (int s = 0; s < l[j].name.Length; s++)
                {
                    if (l[j].name[s] < l[j + 1].name[s])
                    {
                        s = l[j].name.Length;
                    }
                    else if (l[j].name[s] > l[j + 1].name[s])
                    {
                        res = 1;
                        s = l[j].name.Length;
                    }
                }
            }
            else
            {
                for (int s = 0; s < l[j+1].name.Length; s++)
                {
                        if (l[j].name[s] < l[j + 1].name[s])
                        {
                            s = l[j].name.Length;
                        }
                        else if (l[j].name[s] > l[j + 1].name[s])
                        {
                            res = 1;
                            s = l[j].name.Length;
                        }
                }
            }
            if(res == 1)
            {
                n = l[j + 1];
                l[j + 1] = l[j];
                l[j] = n;
            }
        }
    }
}

void sort_z_a(List<Phone> l)
{
    Phone n = new Phone();
    int res = 0;
    for (int i = 0; i < l.Count; i++)
    {
        for (int j = 0; j < (l.Count - 1); j++)
        {
            res = 0;
            if (l[j].name.Length < l[j + 1].name.Length)
            {
                for (int s = 0; s < l[j].name.Length; s++)
                {
                    if (l[j].name[s] > l[j + 1].name[s])
                    {
                        s = l[j].name.Length;
                    }
                    else if (l[j].name[s] < l[j + 1].name[s])
                    {
                        res = 1;
                        s = l[j].name.Length;
                    }
                }
            }
            else
            {
                for (int s = 0; s < l[j + 1].name.Length; s++)
                {
                    if (l[j].name[s] > l[j + 1].name[s])
                    {
                        s = l[j].name.Length;
                    }
                    else if (l[j].name[s] < l[j + 1].name[s])
                    {
                        res = 1;
                        s = l[j].name.Length;
                    }
                }
            }
            if (res == 1)
            {
                n = l[j + 1];
                l[j + 1] = l[j];
                l[j] = n;
            }
        }
    }
}

void search(List<Phone> list, List<Phone> neww, string name)
{
    int res = 0;
    for(int i=0; i<list.Count; i++)
    {
        res = 0;
        if(list[i].name.Length >= name.Length)
        {
            for(int j=0; j<name.Length; j++)
            {
                if(name[j] != list[i].name[j])
                { 
                    res = 1;
                    j = name.Length;
                }
            }
        }
        if (res == 0)
        {
            neww.Add(list[i]);
        }
    }
}

class Phone{
    public string picture { get; set; }
    public string name { get; set; }
    public double price { get; set; }
    public Phone(string p, string n, double pr)
    {
        picture = p;
        name = n;
        price = pr;
    }
    public Phone()
    {

    }
}

class Account {
    public string login { get; set; }
    public string password { get; set; }
    public bool IsAdmin { get; set; }
    public Account(string l, string p, bool i)
    {
        login = l;
        password = p;
        IsAdmin = i;
    }
}
