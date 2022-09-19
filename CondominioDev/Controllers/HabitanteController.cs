using CondominioDev.Context;
using CondominioDev.Dtos;
using CondominioDev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Storage;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CondominioDev.Controllers
{
    [Route("api/[habitante]")]
    [ApiController]
    public class HabitanteController : ControllerBase
    {

        private DevCondominioContext _devCondominioContext;
        private readonly ILogger<HabitanteController> _logger;
        public HabitanteController(DevCondominioContext devCondominioContext,
            ILogger<HabitanteController> logger)
        {
            _devCondominioContext = devCondominioContext;
            _logger = logger;
        }

        /// <summary>
        /// Retorna todos os habitantes
        /// Retorna os usuários que contém o nome enviado
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <returns> Retorna os usuários que possum o mesmo mês data birthdate</returns>
        /// <response code="204"> Caso não encontre resultado, retorna o Status 204 (No Content) </response>
        /// <response code="200"> Caso seja encontrado ao menos um resultado, retorna Status 200 (OK)  </response>
        /// <response code="500"> Em caso de erro na recuperação dos dados, retorna Status 500 </response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Habitante>>> Get(string? name = null, 
            DateTime? birthDate = null)
        {
            try
            {

                List<Habitante> habitantes;
                List<HabitanteDto> habitantesDto = new();
                List<HabitanteDto> TransformDataToDto(List<Habitante> habitantes)
                {
                    List<HabitanteDto> habitantesDtos = new();
                    habitantes.ForEach(habitante =>
                    {
                        var newHabitante = new HabitanteDto()
                        {
                            Id = habitante.Id,
                            Nome = habitante.Nome

                        };
                        habitantesDtos.Add(newHabitante);
                    });
                    return habitantesDtos;
                }

               
                if(name != null && birthDate != null)
                {

                    habitantes = await _devCondominioContext.Habitantes
                        .Where(x => x.Nome == name && x.DataNascimento.Value.Month == birthDate.Value.Month)
                        .ToListAsync();
                    habitantesDto = TransformDataToDto(habitantes);
                    _logger.LogInformation($"Controller: {nameof(HabitanteController)} - Metodo: {nameof(Get)}");
                    if (habitantesDto != null) return Ok(habitantesDto);
                    else return StatusCode(204);

                }
               

                if (name != null)
                {
                    habitantes = await _devCondominioContext.Habitantes.Where(x => x.Nome == name).ToListAsync();
                    habitantesDto = TransformDataToDto(habitantes);
                    _logger.LogInformation($"Controller: {nameof(HabitanteController)} - Metodo: {nameof(Get)}");
                    if (habitantesDto != null) return Ok(habitantesDto);
                    else return StatusCode(204);
                }

                if (birthDate != null)
                {
                    habitantes = await _devCondominioContext.Habitantes
                   .Where(x => x.DataNascimento.Value.Month == birthDate.Value.Month)
                   .ToListAsync();
                    habitantesDto = TransformDataToDto(habitantes);
                    _logger.LogInformation($"Controller: {nameof(HabitanteController)} - Metodo: {nameof(Get)}");
                    if (habitantesDto != null) return Ok(habitantesDto);
                    else return StatusCode(204);
                }

                habitantes = await _devCondominioContext.Habitantes.ToListAsync();
                habitantesDto = TransformDataToDto(habitantes);
                _logger.LogInformation($"Controller: {nameof(HabitanteController)} - Metodo: {nameof(Get)}");
                if (habitantesDto != null) return Ok(habitantesDto);
                else return StatusCode(204);


            }

            catch (Exception e)
            {
                _logger.LogError(e, $"Controller:{nameof(HabitanteController)}-Method:{nameof(Get)}");
                return StatusCode(500);
            }
            
        }

        /// <summary>
        /// Retorna apenas os habitantes com idade igual ou superior a idade
        /// </summary>
        /// <param name="idade">ID do estado</param
        /// <returns>Retorna apenas os habitantes com idade igual ou superior a idade</returns>
        /// <response code="200">Retorna os habitantes a idade pesquisada</response>
        /// <response code="404">Retorno inválido</response>
        /// <response code="500">Ocorreu exceção durante a operação</response>
        [HttpGet("{idade}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Habitante>> GetIdade(int idade)
        {

            try
            {
                var today = DateTime.Today;
                var resultadoIdade = await _devCondominioContext.Habitantes
                    .Where(x => (today.Year - x.DataNascimento.Value.Year) >= idade)
                    .ToListAsync();

                if (resultadoIdade == null)
                    return NotFound();

                _logger.LogError($"Controller:{nameof(HabitanteController)}-Method:{nameof(GetIdade)}");
                return Ok(resultadoIdade);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Controller:{nameof(HabitanteController)}-Method:{nameof(GetIdade)}");
                return StatusCode(500);
            }

        }

        /// <summary>
        /// Retorna habitante pelo id
        /// </summary>
        /// <param name="habitante"></param>
        /// <returns>Retorna o habitante cadastrado no banco de dados</returns>
        /// <response code="200">Retorna usuário</response>
        /// <response code="404">Não encontrou o usuário pesquisado</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpGet("{nome}/{sobrenome}/{dataNascimento}/{renda}/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Habitante>> GetById(int id)
          {
            try
            {
                var habitante = await _devCondominioContext.Habitantes.FirstOrDefaultAsync(x => x.Id == id);
                _logger.LogError($"Controller:{nameof(HabitanteController)}-Method:{nameof(GetById)}");
                return Ok(habitante);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Controller:{nameof(HabitanteController)}-Method:{nameof(GetById)}");
                return StatusCode(500);
            }

        }

        /// <summary>
        /// Inserir habitante
        /// </summary>
        /// <param name="habitante"></param>
        /// <returns>Retorna habitante inserido</returns>
        /// <response code = "201">Usuário inserido com sucesso</response>
        /// <response code = "400">Inserção não realizada</response>
        /// <response code = "500">Erro execução</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody] Habitante habitante)
        {
            try
            {
                bool cpfExiste = _devCondominioContext.Habitantes.Any(x => x.Cpf == habitante.Cpf);
                if (cpfExiste)
                    return BadRequest();

                bool cpfCorreto = new MaxLengthAttribute().IsValid(habitante.Cpf);
                if (!cpfCorreto)
                    return BadRequest();

                _devCondominioContext.Habitantes.Add(habitante);
                await _devCondominioContext.SaveChangesAsync();
                _logger.LogError($"Controller:{nameof(HabitanteController)}-Method:{nameof(Post)}");
                return StatusCode(201);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Controller:{nameof(HabitanteController)}-Method:{nameof(Post)}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Remover habitante
        /// </summary>
        /// <param name="id">Id Endereço</param>
        /// <returns>Habitante excluído com sucesso do banco de dados</returns>
        /// <response code="204">Endereço excluído com sucesso</response>
        /// <response code="400">Exclusão não realizada pois endereço está relacionado a uma entrega</response>
        /// <response code="404">Exclusão não realizada</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {

            try
            {

                var habitante = await _devCondominioContext.Habitantes.FindAsync(id);

                if (habitante is null)
                    return NotFound();

                _devCondominioContext.Habitantes.Remove(habitante);
                await _devCondominioContext.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Controller:{nameof(HabitanteController)}-Method:{nameof(Post)}");
                return StatusCode(500);
            }
        }
    }
}
