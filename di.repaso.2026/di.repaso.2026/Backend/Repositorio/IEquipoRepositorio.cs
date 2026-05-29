namespace di.repaso._2026.Backend.Repositorio
{
    public interface IEquipoRepositorio
    {
        public int getLastId();
        public bool NombreUnico(string nombre);
        public List<string> getDivisiones();
        public List<string> getConferencias();

    }
}