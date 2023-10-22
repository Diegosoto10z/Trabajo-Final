using Structurizr;

namespace c4_model_design
{
	public class ContainerDiagram
	{
		private readonly C4 c4;
		private readonly ContextDiagram contextDiagram;
		public Container MobileApplication { get; private set; }
		public Container WebApplication { get; private set; }
		public Container LandingPage { get; private set; }
		public Container ApiRest { get; private set; }
		public Container Database { get; private set; }

        public Container DatabaseNoSQL { get; private set; }

        public ContainerDiagram(C4 c4, ContextDiagram contextDiagram)
		{
			this.c4 = c4;
			this.contextDiagram = contextDiagram;
		}

		public void Generate() {
			AddContainers();
			AddRelationships();
			ApplyStyles();
			CreateView();
		}

		private void AddContainers()
		{
			MobileApplication = contextDiagram.Plataforma_Tu_Voz_Se_Escucha.AddContainer("Mobile App", "Permite a los usuarios visualizar todos los foros y comunicarse entre ellos.", "Swift UI");
			WebApplication = contextDiagram.Plataforma_Tu_Voz_Se_Escucha.AddContainer("Web App", "Permite visualizar todos los foros y comunicarse entre ellos .", "React");
			LandingPage = contextDiagram.Plataforma_Tu_Voz_Se_Escucha.AddContainer("Landing Page", "", "React");
			ApiRest = contextDiagram.Plataforma_Tu_Voz_Se_Escucha.AddContainer("API REST", "API REST", "NodeJS (NestJS) port 8080");
			Database = contextDiagram.Plataforma_Tu_Voz_Se_Escucha.AddContainer("DB", "", "MySQL Server RDS AWS");
            DatabaseNoSQL = contextDiagram.Plataforma_Tu_Voz_Se_Escucha.AddContainer("DBNOSQL", "", "MyNoSQL Server RDS AWS");
        }

		private void AddRelationships() {
			contextDiagram.Ciudadano.Uses(MobileApplication, "Consulta");
			contextDiagram.Ciudadano.Uses(WebApplication, "Consulta");
			contextDiagram.Ciudadano.Uses(LandingPage, "Consulta");

			contextDiagram.Encargado_Municipal.Uses(MobileApplication, "Consulta");
			contextDiagram.Encargado_Municipal.Uses(WebApplication, "Consulta");
			contextDiagram.Encargado_Municipal.Uses(LandingPage, "Consulta");

            contextDiagram.Gobiernos_Locales.Uses(MobileApplication, "Consulta");
            contextDiagram.Gobiernos_Locales.Uses(WebApplication, "Consulta");
            contextDiagram.Gobiernos_Locales.Uses(LandingPage, "Consulta");

            contextDiagram.Medios_De_Comunicacion.Uses(MobileApplication, "Consulta");
            contextDiagram.Medios_De_Comunicacion.Uses(WebApplication, "Consulta");
            contextDiagram.Medios_De_Comunicacion.Uses(LandingPage, "Consulta");


            MobileApplication.Uses(ApiRest, "API Request", "JSON/HTTPS");
			WebApplication.Uses(ApiRest, "API Request", "JSON/HTTPS");

            ApiRest.Uses(Database, "", "");
            ApiRest.Uses(DatabaseNoSQL, "", "");
            ApiRest.Uses(contextDiagram.Tarjetas_Credito_Debito, "API Request", "JSON/HTTPS");
            ApiRest.Uses(contextDiagram.Redes_Sociales, "API Request", "JSON/HTTPS");
            ApiRest.Uses(contextDiagram.Email, "API Request", "JSON/HTTPS");
        }

		private void ApplyStyles() {
			SetTags();
			Styles styles = c4.ViewSet.Configuration.Styles;
			styles.Add(new ElementStyle(nameof(MobileApplication)) { Background = "#9d33d6", Color = "#ffffff", Shape = Shape.MobileDevicePortrait, Icon = "" });
			styles.Add(new ElementStyle(nameof(WebApplication)) { Background = "#9d33d6", Color = "#ffffff", Shape = Shape.WebBrowser, Icon = "" });
			styles.Add(new ElementStyle(nameof(LandingPage)) { Background = "#929000", Color = "#ffffff", Shape = Shape.WebBrowser, Icon = "" });
			styles.Add(new ElementStyle(nameof(ApiRest)) { Shape = Shape.RoundedBox, Background = "#0000ff", Color = "#ffffff", Icon = "" });
			styles.Add(new ElementStyle(nameof(Database)) { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle(nameof(DatabaseNoSQL)) { Shape = Shape.Cylinder, Background = "#7FFF00", Color = "#ffffff", Icon = "" });

        }

		private void SetTags()
		{
			MobileApplication.AddTags(nameof(MobileApplication));
			WebApplication.AddTags(nameof(WebApplication));
			LandingPage.AddTags(nameof(LandingPage));
			ApiRest.AddTags(nameof(ApiRest));
			Database.AddTags(nameof(Database));
			DatabaseNoSQL.AddTags(nameof(DatabaseNoSQL));
		}

		private void CreateView() {
			ContainerView containerView = c4.ViewSet.CreateContainerView(contextDiagram.Plataforma_Tu_Voz_Se_Escucha, "Contenedor", "Diagrama de Contenedores");
			containerView.AddAllElements();
		}
	}
}