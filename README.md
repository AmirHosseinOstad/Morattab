**Morattab** یک کتابخانه قدرتمند C# است که به شما امکان نمایش زیبا و منظم جداول در کنسول را می‌دهد. این کتابخانه با پشتیبانی از انواع داده‌های مختلف شامل آرایه‌ها، لیست‌ها و کلاس‌های سفارشی، ابزاری کامل برای نمایش اطلاعات جدولی ارائه می‌دهد.

### ✨ **ویژگی‌های کلیدی**
- 🎯 **تنظیم خودکار فاصله‌ها** برای نمایش بهتر
- 📋 **پشتیبانی از آرایه‌های یک و دو بعدی**
- 📊 **کار با لیست‌های Generic**
- 🔧 **قابلیت تنظیم کاراکترهای جداکننده**
- ⚡ **عملکرد بالا و استفاده آسان**
- 🎨 **خروجی زیبا و خوانا**

---

## 🏗️ **ساختار کتابخانه**

### 📁 **کلاس‌های موجود:**

| کلاس | کاربرد | نوع داده پشتیبانی شده |
|-------|--------|----------------------|
| `Record` | تنظیم فاصله فیلدهای جدول | String |
| `TableForArrey` | نمایش جدول از آرایه | Array |
| `TableForList` | نمایش جدول از لیست | List<T> |

---

## 🔧 **راهنمای نصب**

### روش ۱: استفاده مستقیم
```bash
# کلون کردن پروژه
git clone https://github.com/AmirHosseinOstad/Morattab.git

# اضافه کردن namespace
using Morattab;
```

---

## 📚 **راهنمای کامل کلاس‌ها و متدها**

## 🎯 **کلاس Record**

### 📋 **توضیحات:**
کلاسی برای تنظیم فاصله‌های فیلدهای جدول با طول ثابت.

### 🔧 **متدها:**

#### ✅ `FixSpaces(string Input, int RowLength)`
**کاربرد:** تنظیم فاصله فیلد با افزودن فاصله‌های لازم

**پارامترها:**
- `Input`: مقدار فیلد مورد نظر
- `RowLength`: طول درخواستی برای تنظیم فاصله

**خروجی:** رشته با فاصله‌های تنظیم شده

### 💡 **مثال عملی:**

```csharp
using Morattab;

// ایجاد نمونه از کلاس
Record record = new Record();

// استفاده از متد FixSpaces
string name = "احمد";
string formattedName = record.FixSpaces(name, 15);

Console.WriteLine($"[{formattedName}]");
// خروجی: [احمد           ]
```

---

## 📊 **کلاس TableForArrey**

### 📋 **توضیحات:**
کلاسی قدرتمند برای رسم جدول بر اساس آرایه‌های از پیش تعریف شده.

### 🔧 **متدها:**

#### ✅ `FixSpacesAuto(string[] Input, int? AddSpace = 0)`
**کاربرد:** تنظیم خودکار فاصله‌ها برای نمایش بهتر جدول

**پارامترها:**
- `Input`: آرایه یک‌بعدی مقادیر یک سطر از جدول
- `AddSpace`: فاصله اضافی (اختیاری)

**خروجی:** آرایه با فاصله‌های تنظیم شده

### 💡 **مثال عملی:**

```csharp
using Morattab;

TableForArrey table = new TableForArrey();

// آرایه نمونه
string[] data = {"نام", "سن", "شهر"};

// تنظیم خودکار فاصله‌ها
string[] formatted = table.FixSpacesAuto(data, 2);

foreach (var item in formatted)
{
    Console.Write($"[{item}]");
}
// خروجی: [نام  ][سن  ][شهر  ]
```

#### ✅ `FixSpaces(string[] Input, int RowLength)`
**کاربرد:** تنظیم فاصله‌ها با طول مشخص

**پارامترها:**
- `Input`: آرایه یک‌بعدی مقادیر
- `RowLength`: طول سطر برای تنظیم

### 💡 **مثال عملی:**

```csharp
string[] names = {"علی", "فاطمه", "محمد"};
string[] formatted = table.FixSpaces(names, 10);

foreach (var name in formatted)
{
    Console.WriteLine($"|{name}|");
}
// خروجی:
// |علی       |
// |فاطمه     |
// |محمد      |
```

#### ✅ `FixSpaces(string[] Input, int[] RowLength)`
**کاربرد:** تنظیم فاصله‌ها با طول‌های متفاوت برای هر ستون

**پارامترها:**
- `Input`: آرایه یک‌بعدی مقادیر
- `RowLength`: آرایه طول‌های هر ستون

#### ✅ `FixSpacesAuto(string[,] Input, int? AddSpace = 0)`
**کاربرد:** تنظیم خودکار فاصله‌ها برای آرایه دوبعدی

**پارامترها:**
- `Input`: آرایه دوبعدی مقادیر جدول
- `AddSpace`: فاصله اضافی (اختیاری)

### 💡 **مثال کامل آرایه دوبعدی:**

```csharp
using Morattab;

TableForArrey table = new TableForArrey();

// آرایه دوبعدی نمونه
string[,] students = {
    {"نام", "سن", "شهر"},
    {"احمد", "25", "تهران"},
    {"فاطمه", "22", "اصفهان"},
    {"علی", "28", "شیراز"}
};

// تنظیم خودکار فاصله‌ها
string[,] formatted = table.FixSpacesAuto(students, 2);
```

#### ✅ `WriteAuto(string[,] Input, bool? RowsSeparator = false, char? SeparatorLetter = '|', char? RowSeparatorLetter = '-')`
**کاربرد:** نمایش خودکار جدول در کنسول

**پارامترها:**
- `Input`: آرایه دوبعدی داده‌ها
- `RowsSeparator`: نمایش خط جداکننده سطرها
- `SeparatorLetter`: کاراکتر جداکننده ستون‌ها
- `RowSeparatorLetter`: کاراکتر خط جداکننده

### 💡 **مثال نمایش کامل:**

```csharp
using Morattab;

TableForArrey table = new TableForArrey();

string[,] products = {
    {"محصول", "قیمت", "موجودی"},
    {"لپتاپ", "15000000", "5"},
    {"ماوس", "250000", "20"},
    {"کیبورد", "800000", "15"}
};

// نمایش با جداکننده سطری
table.WriteAuto(products, true, '|', '-');

// خروجی:
// محصول  | قیمت     | موجودی |
// -------------------------
// لپتاپ  | 15000000 | 5      |
// -------------------------
// ماوس   | 250000   | 20     |
// -------------------------
// کیبورد | 800000   | 15     |
```

---

## 📋 **کلاس TableForList**

### 📋 **توضیحات:**
کلاسی برای رسم جدول بر اساس لیست‌های از پیش تعریف شده با پشتیبانی از Generic Types.

### 🔧 **متدها:**

#### ✅ `FixSpacesAuto<T>(List<T> Input, int? AddSpace = 0)`
**کاربرد:** تنظیم خودکار فاصله‌ها برای لیست

**پارامترها:**
- `Input`: لیست داده‌های ورودی
- `AddSpace`: فاصله اضافی (اختیاری)

**نوع Generic:** `T` می‌تواند هر کلاس یا نوع داده‌ای باشد

### 💡 **مثال با کلاس سفارشی:**

```csharp
using Morattab;

// تعریف کلاس نمونه
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

// استفاده از TableForList
TableForList tableList = new TableForList();

List<Person> people = new List<Person>
{
    new Person { Name = "احمد", Age = 25, City = "تهران" },
    new Person { Name = "فاطمه", Age = 22, City = "اصفهان" },
    new Person { Name = "علی", Age = 28, City = "شیراز" }
};

// تنظیم فاصله‌ها
List<Person> formatted = tableList.FixSpacesAuto(people, 2);
```

#### ✅ `WriteAuto<T>(List<T> Input, bool? ShowPropsSubject = true, bool? RowsSeparator = false, char? SeparatorLetter = '|', char? RowSeparatorLetter = '-')`
**کاربرد:** نمایش خودکار جدول از لیست در کنسول

**پارامترها:**
- `Input`: لیست داده‌های ورودی
- `ShowPropsSubject`: نمایش عناوین ستون‌ها
- `RowsSeparator`: نمایش خط جداکننده سطرها
- `SeparatorLetter`: کاراکتر جداکننده ستون‌ها
- `RowSeparatorLetter`: کاراکتر خط جداکننده

### 💡 **مثال کامل نمایش لیست:**

```csharp
using Morattab;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

TableForList tableList = new TableForList();

List<Product> products = new List<Product>
{
    new Product { Name = "لپتاپ", Price = 15000000, Stock = 5 },
    new Product { Name = "ماوس", Price = 250000, Stock = 20 },
    new Product { Name = "کیبورد", Price = 800000, Stock = 15 }
};

// نمایش با تمام تنظیمات
tableList.WriteAuto(products, true, true, '║', '═');

// خروجی:
// Name    ║ Price    ║ Stock ║
// ═══════════════════════════
// لپتاپ   ║ 15000000 ║ 5     ║
// ═══════════════════════════
// ماوس    ║ 250000   ║ 20    ║
// ═══════════════════════════
// کیبورد  ║ 800000   ║ 15    ║
```

#### ✅ `Write<T>(List<T> Input, int RowLength, bool? ShowPropsSubject = true, bool? RowsSeparator = false, char? SeparatorLetter = '|', char? RowSeparatorLetter = '-')`
**کاربرد:** نمایش جدول با طول مشخص

**پارامترها:**
- `RowLength`: طول هر فیلد در جدول

---

## 🎨 **مثال‌های پیشرفته**

### 🔥 **مثال ۱: جدول فروش ماهانه**

```csharp
using Morattab;

public class MonthlySales
{
    public string Month { get; set; }
    public decimal Revenue { get; set; }
    public int Orders { get; set; }
    public decimal Profit { get; set; }
}

class Program
{
    static void Main()
    {
        TableForList table = new TableForList();
        
        List<MonthlySales> sales = new List<MonthlySales>
        {
            new MonthlySales { Month = "فروردین", Revenue = 125000000, Orders = 1250, Profit = 15000000 },
            new MonthlySales { Month = "اردیبهشت", Revenue = 98000000, Orders = 980, Profit = 12000000 },
            new MonthlySales { Month = "خرداد", Revenue = 156000000, Orders = 1560, Profit = 20000000 }
        };
        
        Console.WriteLine("📊 گزارش فروش ماهانه");
        Console.WriteLine("".PadRight(50, '='));
        
        table.WriteAuto(sales, true, true, '│', '─');
    }
}
```

### 🔥 **مثال ۲: مقایسه محصولات**

```csharp
using Morattab;

TableForArrey arrayTable = new TableForArrey();

string[,] comparison = {
    {"ویژگی", "محصول A", "محصول B", "محصول C"},
    {"قیمت", "1,500,000 تومان", "2,200,000 تومان", "1,800,000 تومان"},
    {"کیفیت", "عالی", "خیلی عالی", "خوب"},
    {"گارانتی", "2 سال", "3 سال", "1 سال"},
    {"رنگ‌بندی", "3 رنگ", "5 رنگ", "2 رنگ"}
};

Console.WriteLine("🔍 مقایسه محصولات");
Console.WriteLine("".PadRight(60, '='));

arrayTable.WriteAuto(comparison, true, '┃', '━');
```

---

## ⚙️ **تنظیمات پیشرفته**

### 🎛️ **کاراکترهای جداکننده سفارشی:**

```csharp
// استفاده از کاراکترهای Unicode زیبا
table.WriteAuto(data, true, '┃', '━');  // مدرن
table.WriteAuto(data, true, '║', '═');  // کلاسیک
table.WriteAuto(data, true, '│', '─');  // ساده
table.WriteAuto(data, true, '|', '-');  // پایه
```

### 🔧 **بهینه‌سازی عملکرد:**

```csharp
// برای داده‌های بزرگ، از حلقه‌های بهینه استفاده کنید
var largeDataList = new List<MyClass>(10000);

// تنظیم فاصله اضافی برای خوانایی بهتر
var formatted = table.FixSpacesAuto(largeDataList, 1);
```

---

## 🚀 **نکات و بهترین روش‌ها**

### ✅ **نکات مهم:**
- همیشه از `using Morattab;` استفاده کنید
- برای داده‌های فارسی، از encoding مناسب استفاده کنید
- متدهای `Auto` برای سادگی استفاده، متدهای عادی برای کنترل دقیق‌تر

### ⚡ **بهینه‌سازی:**
- برای جداول بزرگ از `FixSpacesAuto` استفاده کنید
- برای کنترل دقیق، طول‌ها را دستی تنظیم کنید
- از Generic Types برای type safety استفاده کنید

### 🎯 **موارد استفاده:**
- 📊 گزارش‌گیری
- 📋 نمایش لیست‌ها
- 📈 جداول آماری
- 🔍 مقایسه داده‌ها
- 💾 خروجی کنسول حرفه‌ای

---

## 🤝 **مشارکت**

این پروژه open source است و از مشارکت شما استقبال می‌کنیم!

### 📝 **نحوه مشارکت:**
1. Repository را Fork کنید
2. تغییرات خود را اعمال کنید
3. Pull Request ارسال کنید

### 🐛 **گزارش باگ:**
برای گزارش مشکلات، در بخش Issues گیت‌هاب اقدام کنید.

---

## 📄 **مجوز**

این پروژه تحت مجوز MIT منتشر شده است.

---


---

<div align="center">

**⭐ منتظر ستاره های گرمتون هستیم! ⭐**

**ساخته شده با ❤️ برای جامعه توسعه‌دهندگان ایرانی**

</div>
