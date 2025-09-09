using Vertroue.HMS.API.Application.Features.Categories.Commands.CreateCategory;
using Vertroue.HMS.API.Application.Features.Categories.Queries.GetCategoriesList;
using Vertroue.HMS.API.Application.Features.Categories.Queries.GetCategoriesListWithProducts;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vertroue.HMS.API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        //Scopes
        private const string _readScope = "readAccess";
        private const string _writeScope = "writeAccess";
        private const string _adminScope = "adminAccess";

        //App roles
        private const string _readRole = "App.Read";
        private const string _writeRole = "App.Write";
        private const string _adminRole = "App.Admin";

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]        
        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(dtos);
        }

        [Authorize]
        //[RequiredScopeOrAppPermission( AcceptedScope = new string[] { _adminScope, _writeScope  }, AcceptedAppPermission = new string[] { _adminRole, _writeRole })]
        [HttpGet("allwithproducts", Name = "GetCategoriesWithProducts")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryProductListVm>>> GetCategoriesWithProducts()
        {
            GetCategoriesListWithProductsQuery getCategoriesListWithProductsQuery = new GetCategoriesListWithProductsQuery() { };

            var dtos = await _mediator.Send(getCategoriesListWithProductsQuery);
            return Ok(dtos);
        }

        [Authorize]
        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }
    }
}
