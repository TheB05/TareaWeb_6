
using System.Text.Json;

public class Excerpt
    {
        public string rendered { get; set; }
        public bool @protected { get; set; }
    }

    public class Noticia
    {
        public Title title { get; set; }
        public Excerpt excerpt { get; set; }
    }

    public class Title
    {
        public string rendered { get; set; }
    }


class Paso1{

    public static async Task<ServerResult> Ejecutar(){

        try{
        var url = "https://remolacha.net/wp-json/wp/v2/posts?search=migraci%C3%B3n&_fields=title,excerpt";
        var client = new HttpClient();
        var response = await client.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();
        var noticias = JsonSerializer.Deserialize<List<Noticia>>(json);
        
        return new ServerResult(true, "Noticias cargadas", noticias);
        }
        catch(Exception ex){
            return new ServerResult(false, ex.Message);
        }

    }
}