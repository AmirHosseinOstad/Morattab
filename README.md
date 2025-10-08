# کتابخانه مرتب

کتابخانه‌ای ساده و کارآمد برای نمایش داده‌ها به صورت جدول در کنسول C#. این کتابخانه امکان تبدیل آرایه‌ها و لیست‌ها به جداول زیبا و منظم را فراهم می‌کند.

## نمونه کد رسم جدول
```csharp
using Morattab;

Table table = new Table()
        {
            //Set features
            RowsSeparator = true,
            RowSeparatorLetter = '_',
            SeparatorLetter = '|'
        };

//Add rows to the table
table.Add(new string[] { "Name", "Last Name", "Age" });
table.Add(new string[] { "Amir Hossein", "Ostad", "18" });
table.Add(new string[] { "Michael", "Scofield", "35" });

//Print table
table.Write();
```

## کلاس‌های موجود
### 1. Table

کلاسی برای تعریف جدول، افزودن رکورد و نمایش آن

#### متدها

**Add(string[] Record)**
- ورودی تابع آرایه‌ای از نوع رشته که یک سطر از جدول را مشخص می‌کند، هر اندیس بیانگر مقدار یک ستون است.
  
**Write()**
- نمایش جدول تعریف شده در کنسول
- قابلیت تنظیم جداکننده‌های ستون و ردیف
- امکان نمایش خطوط جداکننده بین ردیف‌ها

**مثال استفاده:**

```csharp
using Morattab;

class Program
{
    static void Main()
    {
        Table table = new Table();

        table.Add(new string[] { "FirstName", "LastName", "Age" });
        table.Add(new string[] { "Amir Hossein", "Ostad", "18" });
        table.Add(new string[] { "Michael", "Scofilde", "30" });

        table.Write(0, true);
    }
}
```

نتیجه:
<br/>
<img width="811" height="218" alt="{52C317B8-AFEB-4895-A07A-68B4FA6E27E7}" src="https://github.com/user-attachments/assets/21f04d58-d817-4c86-b39f-90a73097e194" />


### 2. Record

کلاسی برای تنظیم فاصله‌گذاری فیلدهای تک‌رکورد

#### متدها

**FixSpaces(string Input, int RowLength)**
- تنظیم طول ثابت برای یک رشته با اضافه کردن فاصله‌های لازم
- اگر ورودی طولانی‌تر از حد مجاز باشد، آن را کوتاه می‌کند
- اگر کوتاه‌تر باشد، فاصله‌های مورد نیاز را اضافه می‌کند

**مثال استفاده:**

```csharp
using Morattab;

class Program
{
    static void Main()
    {
        Record record = new Record();
        
        string name = "John";
        string formattedName = record.FixSpaces(name, 15);
        
        Console.WriteLine($"[{formattedName}]");
    }
}
```

### 3. TableForArrey

کلاسی برای ایجاد جدول از آرایه‌های یک‌بعدی و دوبعدی

#### متدها

**FixSpaces(string[] Input, int RowLength = 0, int? AddSpace = 0)**
- تنظیم فاصله‌گذاری برای آرایه یک‌بعدی
- اگر RowLength صفر باشد، به طور خودکار بیشترین طول را پیدا می‌کند
- AddSpace برای اضافه کردن فاصله اضافی استفاده می‌شود

**FixSpaces(string[] Input, int[] RowLength)**
- تنظیم فاصله‌گذاری با طول‌های مختلف برای هر ستون

**FixSpaces(string[,] Input, int RowLengthInput = 0, int? AddSpace = 0)**
- تنظیم فاصله‌گذاری برای آرایه دوبعدی
- برای هر ستون جداگانه بیشترین طول را محاسبه می‌کند

**FixSpaces(string[,] Input, int[] RowLength)**
- تنظیم فاصله‌گذاری دوبعدی با طول‌های از پیش تعریف شده

**Write(string[,] InputArray, int RowLength = 0, bool? RowsSeparator = false, char? SeparatorLetter = '|', char? RowSeparatorLetter = '-')**
- نمایش جدول در کنسول
- قابلیت تنظیم جداکننده‌های ستون و ردیف
- امکان نمایش خطوط جداکننده بین ردیف‌ها

**نمونه‌های استفاده:**

```csharp
using Morattab;

class Program
{
    static void Main()
    {
        TableForArrey tableArray = new TableForArrey();
        
        // نمونه آرایه یک‌بعدی
        string[] singleArray = {"Name", "Age", "City"};
        string[] fixedArray = tableArray.FixSpaces(singleArray, 12, 2);
        
        // نمونه آرایه دوبعدی
        string[,] data = {
            {"Name", "Age", "City"},
            {"Alice", "25", "New York"},
            {"Bob", "30", "London"},
            {"Charlie", "22", "Tokyo"}
        };
        
        // نمایش جدول
        tableArray.Write(data, 0, true, '|', '-');
    }
}
```

نتیجه:
<br/>
<img width="981" height="259" alt="{0E3D97D6-84EB-430C-960D-EE3650AAE708}" src="https://github.com/user-attachments/assets/539ddc4a-6732-49a4-832d-f7f006ba8dc2" />



### 4. TableForList

کلاسی برای ایجاد جدول از لیست‌های شیء

#### متدها

**FixSpaces<T>(List<T> Input, int RowLengthInput = 0, int? AddSpace = 0)**
- تنظیم فاصله‌گذاری برای لیست اشیاء
- با استفاده از Reflection خصوصیات اشیاء را خوانده و جدول می‌سازد
- خودکار طول هر ستون را بر اساس محتوا تنظیم می‌کند

**FixSpaces<T>(List<T> Input, int[] RowLength)**
- تنظیم فاصله‌گذاری با طول‌های از پیش تعریف شده برای هر ستون

**Write<T>(List<T> InputList, int RowLength = 0, bool? ShowPropsSubject = true, bool? RowsSeparator = false, char? SeparatorLetter = '|', char? RowSeparatorLetter = '-')**
- نمایش جدول از لیست اشیاء
- ShowPropsSubject برای نمایش عناوین ستون‌ها استفاده می‌شود
- سایر پارامترها مشابه TableForArrey هستند

**نمونه استفاده:**

```csharp
using Morattab;
using System.Collections.Generic;

// تعریف کلاس نمونه
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

class Program
{
    static void Main()
    {
        TableForList tableList = new TableForList();
        
        // ایجاد لیست نمونه
        List<Person> people = new List<Person>
        {
            new Person { Name = "Alice", Age = 25, City = "New York" },
            new Person { Name = "Bob", Age = 30, City = "London" },
            new Person { Name = "Charlie", Age = 22, City = "Tokyo" },
            new Person { Name = "Diana", Age = 28, City = "Paris" }
        };
        
        // نمایش جدول با عناوین و جداکننده
        tableList.Write(people, 0, true, true, '|', '-');
        // نمایش بدون عناوین
        tableList.Write(people, 15, false, false, '│', '─');
    }
}
```

نتیجه نمایش جدول با عناوین و جداکننده:
<br/>
<img width="1028" height="333" alt="{AFF5FCC4-7A82-4A2C-BC24-B2B68A43C903}" src="https://github.com/user-attachments/assets/d61f3eea-7c56-46a0-b256-dc0638a71ede" />


نتیجه نمایش بدون عناوین:
<br/>
<img width="984" height="166" alt="image" src="https://github.com/user-attachments/assets/b951b839-d32b-4fb4-9a56-7dac4f5192fd" />


## ویژگی‌ها

- **انعطاف‌پذیری**: پشتیبانی از آرایه‌ها، لیست‌ها و اشیاء سفارشی
- **تنظیم خودکار**: محاسبه خودکار عرض ستون‌ها بر اساس محتوا
- **سفارشی‌سازی**: امکان تغییر جداکننده‌ها و خطوط جدول
- **سادگی**: استفاده آسان با پارامترهای اختیاری

## نصب

فایل‌های کتابخانه را در پروژه خود کپی کنید و namespace مربوطه را import نمایید:

```csharp
using Morattab;
```

## نکات مهم

- برای حالت خودکار، RowLength را 0 بگذارید
- از AddSpace برای فاصله اضافی بین ستون‌ها استفاده کنید  
- RowsSeparator خطوط افقی بین ردیف‌ها را کنترل می‌کند
- جداکننده‌ها قابل تنظیم هستند و می‌توانید کاراکترهای مختلف استفاده کنید

این کتابخانه برای نمایش داده‌ها در application های کنسول بسیار مفید است و کار شما را در قالب‌بندی خروجی‌ها بسیار ساده‌تر می‌کند.
