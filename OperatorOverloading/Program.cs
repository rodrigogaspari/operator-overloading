Console.WriteLine("Overloadin Operators Example:");

var perfilA = new Perfil("Perfil A", ETipoPerfil.Administrativo, EAcessosPerfil.MenuA | EAcessosPerfil.MenuB);
Console.WriteLine(perfilA);

var perfilB = new Perfil("Perfil B", ETipoPerfil.Usuario, EAcessosPerfil.MenuC | EAcessosPerfil.MenuD);
Console.WriteLine(perfilB);

//A + B
Console.WriteLine(perfilA + perfilB);

public record Perfil(string Nome, ETipoPerfil Tipo, EAcessosPerfil Acessos)
{
    public static Perfil operator +(Perfil obj1, Perfil obj2)
    {
        return new Perfil(
            $"{obj1.Nome} + {obj2.Nome}", 
            obj1.Tipo | obj2.Tipo, 
            obj1.Acessos | obj2.Acessos);
    }

    public override string ToString()
    {
        return 
            $"Nome: {Nome}, " +
            $"Tipo: {Tipo}, " +
            $"Acessos: {Acessos}";
    }
}

[Flags]
public enum ETipoPerfil
{ 
    Administrativo = 1,
    Usuario = 2,
}

[Flags]
public enum EAcessosPerfil
{ 
    MenuA = 1, 
    MenuB = 2, 
    MenuC = 4, 
    MenuD = 8,
    MenuE = 16,
}