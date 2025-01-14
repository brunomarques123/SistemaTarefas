﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repository.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> BuscarTodosTarefas()
        {
            List<TarefaModel> tarefas = await _tarefaRepository.BuscarTodosTarefas();
            return Ok(tarefas);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
        {
            TarefaModel tarefas = await _tarefaRepository.BuscarPorId(id);
            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepository.Adicionar(tarefaModel);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _tarefaRepository.Atualizar(tarefaModel, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> Apagar(int id)
        {
            bool apagado = await _tarefaRepository.Apagar(id);
            return Ok(apagado);
        }


    }
}
