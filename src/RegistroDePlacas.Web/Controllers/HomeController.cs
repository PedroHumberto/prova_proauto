using System.Diagnostics;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using RegistroDePlacas.Application.Commands;
using RegistroDePlacas.Web.Models;

namespace RegistroDePlacas.Web.Controllers;

public class HomeController : Controller
{
    private readonly HttpClient _httpClient;

    public HomeController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IActionResult Index()
    {
        if (TempData.ContainsKey("SuccessMessage"))
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
        }



        return View();
    }
    [HttpGet]
    public async Task<IActionResult> Registrar()
    {
        if (TempData.ContainsKey("ErrorMessage"))
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(UsuarioViewModel usuario)
    {
        var jsonContent = JsonSerializer.Serialize(usuario);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://localhost:5270/api/usuario/cadastrar", content);

        var responseBody = await response.Content.ReadAsStringAsync();

        // Opções de deserialização
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        var apiResponse = JsonSerializer.Deserialize<GenericCommandResult>(responseBody, options);

        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = apiResponse?.Message ?? "Usuario cadastrado com sucesso";
            return RedirectToAction("Index");
        }

        TempData["ErrorMessage"] = apiResponse?.Message ?? "Erro ao criar usuário";
        return RedirectToAction("Registrar");
    }

    [HttpGet]
    public IActionResult Atualizar()
    {
        if (TempData.ContainsKey("ErrorMessage"))
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Atualizar(AtualizarEnderecoViewModel model)
    {

        var jsonContent = JsonSerializer.Serialize(model);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://localhost:5270/api/usuario/update_endereco", content);

        var responseBody = await response.Content.ReadAsStringAsync();

        // Opções de deserialização
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        var apiResponse = JsonSerializer.Deserialize<GenericCommandResult>(responseBody, options);

        Console.WriteLine("RESPONSE = " + responseBody);

        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = apiResponse?.Message ?? "Endereço com sucesso";
            return RedirectToAction("Index");
        }

        TempData["ErrorMessage"] = apiResponse?.Message ?? "Erro ao atualizar o endereço";
        return RedirectToAction("Atualizar");

    }



}
