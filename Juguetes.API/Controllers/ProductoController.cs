using AutoMapper;
using Juguetes.BL.Data;
using Juguetes.BL.DTOs;
using Juguetes.BL.Models;
using Juguetes.BL.Repositories.Implements;
using Juguetes.BL.Services.Implements;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Juguetes.API.Controllers
{
    
    [RoutePrefix("api/Producto")]
    public class ProductoController : ApiController
    {
        private IMapper mapper;
       private readonly ProductoService productoService = new ProductoService(new ProductoRepository(JuguetesContext.Create()));
        public ProductoController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var productos = await productoService.GetAll();
            var productosDTO = productos.Select(x => mapper.Map<ProductoDTO>(x));
            return Ok(productosDTO);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var productos = await productoService.GetById(id);
            if (productos == null)
                return NotFound();

            var productosDTO = mapper.Map<ProductoDTO>(productos);
            return Ok(productosDTO);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(ProductoDTO productoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                var producto = mapper.Map<Productos>(productoDTO);
                producto = await productoService.Insert(producto);
                return Ok(producto);
            }
            catch (Exception ex )
            {

                return InternalServerError(ex);
            }


            
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put(ProductoDTO productoDTO,int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if(productoDTO.Id!= id)
                return BadRequest(ModelState);

            var flag = await productoService.GetById(id);
            if (flag == null)
                return NotFound();
            try
            {
                var producto = mapper.Map<Productos>(productoDTO);
                producto = await productoService.Update(producto);
                return Ok(producto);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }



        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await productoService.GetById(id);
            if (flag == null)
                return NotFound();
            try
            {
                await productoService.Delete(id);
                return Ok();

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            
        }

    }
}