@model ConsultaViewModel

    <h2>Nova Consulta</h2>

    <form asp-action="Create">
    <div class="form-group">
    <label asp-for="PacienteId"></label>
    <select asp-for="PacienteId" class="form-control" asp-items="Model.Pacientes">
    <option value="">Selecione um Paciente</option>
    </select>
    </div>
    <div class="form-group">
    <label asp-for="DentistaId"></label>
    <select asp-for="DentistaId" class="form-control" asp-items="Model.Dentistas">
    <option value="">Selecione um Dentista</option>
    </select>
    </div>
    <div class="form-group">
    <label asp-for="DataConsulta"></label>
    <input asp-for="DataConsulta" class="form-control" />
    <span asp-validation-for="DataConsulta" class="text-danger"></span>
    </div>
    <button type="submit" class="btn btn-primary">Salvar</button>
    </form>