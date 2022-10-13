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
    /// <summary>
    /// Clase Controller para el manejo de la informacion.
    /// </summary>
    
    [RoutePrefix("api/Producto")]
    public class ProductoController : ApiController
    {
        private IMapper mapper;
       private readonly ProductoService productoService = new ProductoService(new ProductoRepository(JuguetesContext.Create()));
        /// <summary>
        /// Constructor de la clase controller
        /// </summary>
        public ProductoController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        /// <summary>
        /// Obtiene Todos los Registros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var productos = await productoService.GetAll();
            var productosDTO = productos.Select(x => mapper.Map<ProductoDTO>(x));
            return Ok(productosDTO);
        }
        /// <summary>
        /// Obtiene los registros de acuerdo al id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var productos = await productoService.GetById(id);
            if (productos == null)
                return NotFound();

            var productosDTO = mapper.Map<ProductoDTO>(productos);
            return Ok(productosDTO);
        }
        /// <summary>
        /// Inserta un nuevo registro
        /// </summary>
        /// <param name="productoDTO"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Modifica registro existente
        /// </summary>
        /// <param name="productoDTO"></param>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Elimina registro de acuerdo al id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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