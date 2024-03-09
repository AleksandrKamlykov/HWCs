using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWCs
{

    class Analytic
    {
        private List<Product> products;
        private List<Sale> sales;

        public Analytic(List<Product> products, List<Sale> sales)
        {
            this.products = products;
            this.sales = sales;
        }

        public void TotalSalesByCategory()
        {
            var totalSalesByCategory = sales
                .Join(products, sale => sale.ProductID, product => product.ID, (sale, product) => new { sale, product })
                .GroupBy(pair => pair.product.Category)
                .Select(group => new
                {
                    Category = group.Key,
                    TotalSales = group.Sum(pair => pair.sale.Quantity)
                });

            foreach (var categorySale in totalSalesByCategory)
            {
                Console.WriteLine($"Category: {categorySale.Category}, Total Sales: {categorySale.TotalSales}");
            }
        }

        public void MostPopularProduct()
        {
            var mostPopularProduct = sales
                .GroupBy(sale => sale.ProductID)
                .Select(group => new
                {
                    ProductID = group.Key,
                    TotalSales = group.Sum(sale => sale.Quantity)
                })
                .OrderByDescending(product => product.TotalSales)
                .First();

            var product = products.First(p => p.ID == mostPopularProduct.ProductID);

            Console.WriteLine($"Most Popular Product: {product.Name}, Total Sales: {mostPopularProduct.TotalSales}");
        }

        public void SalesByMonth()
        {
            var salesByMonth = sales
                .GroupBy(sale => sale.SaleDate.Month)
                .Select(group => new
                {
                    Month = group.Key,
                    TotalSales = group.Sum(sale => sale.Quantity)
                })
                .OrderByDescending(sale => sale.TotalSales);

            foreach (var sale in salesByMonth)
            {
                Console.WriteLine($"Month: {sale.Month}, Total Sales: {sale.TotalSales}");
            }
        }

        public void AveragePriceByCategory()
        {
            var averagePriceByCategory = sales
                .Join(products, sale => sale.ProductID, product => product.ID, (sale, product) => new { sale, product })
                .GroupBy(pair => pair.product.Category)
                .Select(group => new
                {
                    Category = group.Key,
                    AveragePrice = group.Sum(pair => pair.product.Price * pair.sale.Quantity) / group.Sum(pair => pair.sale.Quantity)
                });

            foreach (var averagePrice in averagePriceByCategory)
            {
                Console.WriteLine($"Category: {averagePrice.Category}, Average Price: {averagePrice.AveragePrice}");
            }
        }

        public void SalesTrendByCategory(string category)
        {
            var salesTrend = sales
                .Join(products, sale => sale.ProductID, product => product.ID, (sale, product) => new { sale, product })
                .Where(pair => pair.product.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .GroupBy(pair => pair.sale.SaleDate.Month)
                .Select(group => new
                {
                    Month = group.Key,
                    TotalSales = group.Sum(pair => pair.sale.Quantity)
                });

            Console.WriteLine($"Sales Trend for Category '{category}':");
            foreach (var sale in salesTrend)
            {
                Console.WriteLine($"Month: {sale.Month}, Total Sales: {sale.TotalSales}");
            }
        }
    }
}