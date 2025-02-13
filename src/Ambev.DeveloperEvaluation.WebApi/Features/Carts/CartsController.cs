using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts
{
    /// <summary>
    /// Controlador para gerenciar o carrinho de compras
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CartsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;





        /// <summary>
        /// Construtor da classe CartsController
        /// </summary>
        /// <param name="mediator">Mediator</param>
        /// <param name="mapper">AutoMapper</param>
        public CartsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }





        /// <summary>
        /// Criar um Carrinho de Compras
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CartResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartRequest createCartRequest, CancellationToken cancellationToken)
        {
            var validator = new CreateCartRequestValidator();
            var validationResult = await validator.ValidateAsync(createCartRequest, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var createCartCommand = _mapper.Map<Application.Carts.CreateCart.CreateCartCommand>(createCartRequest);
            var result = await _mediator.Send(createCartCommand, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CartResponse>
            {
                Success = true,
                Message = "Carrinho de compras criado com sucesso.",
                Data = _mapper.Map<CartResponse>(result)
            });
        }





        /// <summary>
        /// Selecionar todos os carrino de compras
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseWithData<GetCartListResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCartList(CancellationToken cancellationToken)
        {
            var getCartListRequest = new GetCartListRequest();
            var command = _mapper.Map<Application.Carts.GetCart.GetCartListCommand>(getCartListRequest);
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetCartListResponse>
            {
                Success = true,
                Message = "Lista de carrinho de compras carregada com sucesso.",
                Data = _mapper.Map<GetCartListResponse>(result)
            });

        }




        ///// <summary>
        ///// Selecionar um carrino de compras pelo identificador
        ///// </summary>
        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(ApiResponseWithData<CartResponse>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetCartById([FromRoute] Guid id, CancellationToken cancellationToken)
        //{
        //    //var request = new GetCartByIdRequest { Id = id };
        //    //var validator = new GetCartByIdRequestValidator();
        //    //var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //    //if (!validationResult.IsValid)
        //    //    return BadRequest(validationResult.Errors);

        //    //var command = _mapper.Map<Application.Carts.GetCart.GetCartByIdCommand>(request.Id);
        //    //var response = await _mediator.Send(command, cancellationToken);

        //    //return Ok(new ApiResponseWithData<CartResponse>
        //    //{
        //    //    Success = true,
        //    //    Message = "Cart retrieved successfully",
        //    //    Data = _mapper.Map<CartResponse>(response)
        //    //});

        //    return Ok();
        //}





        ///// <summary>
        ///// Atualizar um carrinho de compras
        ///// </summary>
        //[HttpPut("{id}")]
        //[ProducesResponseType(typeof(ApiResponseWithData<CartResponse>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> UpdateCart([FromRoute] Guid id, [FromBody] UpdateCartRequest updateCartRequest, CancellationToken cancellationToken)
        //{
        //    var request = new UpdateCartRequest();
        //    request = _mapper.Map<UpdateCartRequest>(cartRequest);
        //    request.Id = id;

        //    var validator = new UpdateCartRequestValidator();
        //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors);

        //    var command = _mapper.Map<Application.Carts.UpdateCart.UpdateCartCommand>(request);
        //    var result = await _mediator.Send(command, cancellationToken);

        //    return Ok(new ApiResponseWithData<CartResponse>
        //    {
        //        Success = true,
        //        Message = "Cart updated successfully",
        //        Data = _mapper.Map<CartResponse>(result)
        //    });


        //}





        ///// <summary>
        ///// Excluir um carrinho de compras
        ///// </summary>
        //[HttpDelete("{id}")]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> DeleteCart([FromRoute] Guid id, CancellationToken cancellationToken)
        //{
        //    //var request = new DeleteCartRequest { Id = id };
        //    //var validator = new DeleteCartRequestValidator();
        //    //var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //    //if (!validationResult.IsValid)
        //    //    return BadRequest(validationResult.Errors);

        //    //var command = _mapper.Map<Application.Carts.DeleteCart.DeleteCartCommand>(request.Id);
        //    //await _mediator.Send(command, cancellationToken);

        //    //return Ok(new ApiResponse
        //    //{
        //    //    Success = true,
        //    //    Message = "Cart deleted successfully"
        //    //});

        //    return Ok();
        //}
    }
}
