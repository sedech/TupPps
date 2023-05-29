using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TupPps.Models;
using TupPps.Data;
using TupPps.Models.Response;
using TupPps.Models.Request;


namespace TupPps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            Respuesta oRepuesta = new Respuesta();
            oRepuesta.Exito = 0;
            try
            {
                using (FerreTechContext db = new FerreTechContext())
                {
                    var lst = db.Productos.ToList();
                    oRepuesta.Exito = 1;
                    oRepuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRepuesta.Mensaje = ex.Message;
            }
            return Ok(oRepuesta);
        }
        [HttpPost]

        public IActionResult Add(ProductoRequest oModel) 
        { 
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using(FerreTechContext db = new FerreTechContext())
                {
                    Producto oProducto = new Producto();
                    oProducto.Descripcion = oProducto.Descripcion;
                    db.Productos.Add(oProducto);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje=ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpPut]
        public IActionResult Edit(ProductoRequest oModel)
        {
            Respuesta oRespuesta=new Respuesta();

            try
            {
                using (FerreTechContext db = new FerreTechContext())
                {
                    Producto oProducto = db.Productos.Find(oModel.IdProducto);
                    oProducto.Descripcion = oModel.Descripcion;
                    db.Entry(oProducto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }    
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{IdProducto}")]
        public IActionResult Delete(int IdProducto)
        {
            Repuesta oRepuesta = new Respuesta();
            
            try
            {
                using (FerreTechContext db = new FerreTechContext())
                {
                    Producto oProducto = db.Productos.Find(IdProducto);
                    db.Remove(oProducto);
                    db.SaveChanges();
                     oRepuesta.Exito = 1;
                }
            }
                catch (Exception ex) 
                {   
                     oRepuesta.Mensaje = ex.Message;
                }
                return Ok(oRepuesta);
            

        }
    }
}
