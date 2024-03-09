using HWCs;

List<Product> products = new List<Product>
        {
            new Product { ID = 1, Name = "Product A", Category = "Category 1", Price = 10.0 },
            new Product { ID = 2, Name = "Product B", Category = "Category 2", Price = 15.0 },
            new Product { ID = 3, Name = "Product C", Category = "Category 1", Price = 20.0 }
        };

List<Sale> sales = new List<Sale>
        {
            new Sale { SaleID = 1, ProductID = 1, Quantity = 5, SaleDate = new DateTime(2024, 1, 15) },
            new Sale { SaleID = 2, ProductID = 2, Quantity = 10, SaleDate = new DateTime(2024, 2, 20) },
            new Sale { SaleID = 3, ProductID = 1, Quantity = 8, SaleDate = new DateTime(2024, 3, 10) },
            new Sale { SaleID = 4, ProductID = 3, Quantity = 12, SaleDate = new DateTime(2024, 1, 25) }
        };

Analytic analyzer = new Analytic(products, sales);

// Подсчет общего количества продаж по категориям
Console.WriteLine("Total Sales by Category:");
analyzer.TotalSalesByCategory();
Console.WriteLine();

// Определение самого популярного продукта
Console.WriteLine("Most Popular Product:");
analyzer.MostPopularProduct();
Console.WriteLine();

// Анализ продаж по месяцам
Console.WriteLine("Sales by Month:");
analyzer.SalesByMonth();
Console.WriteLine();

// Средняя цена продажи по категориям
Console.WriteLine("Average Price by Category:");
analyzer.AveragePriceByCategory();
Console.WriteLine();

// Динамика продаж для выбранной категории
string selectedCategory = "Category 1";
analyzer.SalesTrendByCategory(selectedCategory);