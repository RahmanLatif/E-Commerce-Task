using E_Commerce_Task.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Hosting;
using System.Web.Mvc;

namespace E_Commerce_Task.Controllers
{
    public class ProductsController : Controller
    {
        ProductService service;

        public ProductsController()
        {
            service = new ProductService();
        }
        // GET: Products
        public ActionResult Index()
        {
            var products = service.GetProducts("All");
            return View(products);
        }

        public ActionResult GetProductsByCategory(string category)
        {
            List<ProductDTO> products = service.GetProducts(category);
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProduct(int id)
        {
            var product = service.GetProduct(id);
            return View(product);
        }

        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductViewModel product)
        {
            try
            {
                string path = Server.MapPath("~/Content/images/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileName = "";
                if (product.ProductImage != null)
                {
                    fileName = Path.GetFileName(product.ProductImage.FileName);
                    product.ProductImage.SaveAs(path + fileName);
                    ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                }
                else
                {
                    return View(product);
                }
                ProductDTO productDTO = new ProductDTO()
                {
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    Category = product.Category,
                    Price = product.Price,
                    ProductImage = fileName
                };
                service.AddProduct(productDTO);
            }
            catch (Exception ex)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditProduct(int id)
        {
            var product = service.GetProduct(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(int id, ProductViewModel product)
        {
            try
            {
                string path = Server.MapPath("~/Content/images/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileName = "";
                if (product.ProductImage != null)
                {
                    fileName = Path.GetFileName(product.ProductImage.FileName);
                    product.ProductImage.SaveAs(path + fileName);
                    ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                }
                ProductDTO productDTO = service.GetProduct(id);
                productDTO.ProductName = product.ProductName;
                productDTO.ProductDescription = product.ProductDescription;
                productDTO.Category = product.Category;
                productDTO.Price = product.Price;
                productDTO.ProductImage = fileName;
                service.EditProduct(id, productDTO);
            }
            catch (Exception ex)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                service.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}