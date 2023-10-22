using Structurizr;

namespace c4_model_design
{
	public class APIRestComponentDiagram
	{
		private readonly C4 c4;
		private readonly ContextDiagram contextDiagram;
		private readonly ContainerDiagram containerDiagram;
        private readonly string componentTag = "Component";
        public Component Informes { get; private set; }
        public Component SharedKernel { get; private set; }
        public Component Notificaciones { get; private set; }
        public Component Colaboraci�n { get; private set; }
        public Component Soporte { get; private set; }
        public Component Encuestas { get; private set; }
        public Component Evaluacion { get; private set; }
        public Component Seguimiento { get; private set; }
        public Component Promocion { get; private set; }
        public Component Comunicaci�n { get; private set; }

        public APIRestComponentDiagram(C4 c4, ContextDiagram contextDiagram, ContainerDiagram containerDiagram)
		{
			this.c4 = c4;
			this.contextDiagram = contextDiagram;
			this.containerDiagram = containerDiagram;
		}

		public void Generate() {
			AddComponents();
			AddRelationships();
			ApplyStyles();
			CreateView();
		}

		private void AddComponents()
		{
            SharedKernel = containerDiagram.ApiRest.AddComponent("SharedKernel", "", "NodeJS (NestJS)");
            Informes = containerDiagram.ApiRest.AddComponent("Informes de Problemas", "Este m�dulo permite a los usuarios presentar informes detallados sobre problemas de seguridad y calidad p�blica en sus �reas locales.", "NodeJS (NestJS)");
            Notificaciones = containerDiagram.ApiRest.AddComponent("Alertas y Notificaciones", "En este m�dulo se gestionan las alertas y notificaciones enviadas a los usuarios.", "NodeJS (NestJS)");
            Colaboraci�n = containerDiagram.ApiRest.AddComponent("Colaboraci�n Comunitaria", "Este m�dulo proporciona un espacio para la comunicaci�n y colaboraci�n entre los miembros de la comunidad.", "NodeJS (NestJS)");
            Soporte = containerDiagram.ApiRest.AddComponent("Soporte y Asistencia", "Ofrece soporte t�cnico y asistencia a los usuarios que tengan preguntas o problemas con la plataforma.", "NodeJS (NestJS)");
            Encuestas = containerDiagram.ApiRest.AddComponent("Encuestas y Retroalimentaci�n", ": Este m�dulo permite a la comunidad realizar encuestas y proporcionar retroalimentaci�n sobre proyectos y servicios locales, lo que gu�a la toma de decisiones.", "NodeJS (NestJS)");
            Evaluacion = containerDiagram.ApiRest.AddComponent("Evaluaci�n de Servicios P�blicos", ": Los usuarios pueden evaluar y comentar sobre servicios p�blicos locales, como transporte p�blico y recolecci�n de basura, para impulsar mejoras.", "NodeJS (NestJS)");
            Seguimiento = containerDiagram.ApiRest.AddComponent("Seguimiento de Medios de Comunicaci�n", "Permite a los usuarios hacer un seguimiento de noticias locales y eventos relevantes en los medios de comunicaci�n, lo que facilita la comprensi�n de la comunidad sobre temas actuales.", "NodeJS (NestJS)");
            Promocion = containerDiagram.ApiRest.AddComponent("Promoci�n de Eventos Culturales", "Permite a los organizadores de eventos locales promocionar sus actividades culturales, lo que enriquece la vida cultural de la comunidad.", "NodeJS (NestJS)");
            Comunicaci�n = containerDiagram.ApiRest.AddComponent("Comunicaci�n de Eventos Deportivos", ": Permite a los organizadores de eventos deportivos locales comunicar horarios, resultados y detalles importantes a la comunidad deportiva.", "NodeJS (NestJS)");

        }

		private void AddRelationships() {
			Informes.Uses(containerDiagram.Database, "Usa", "");
			Informes.Uses(this.SharedKernel, "Usa", "");

            Notificaciones.Uses(containerDiagram.Database, "Usa", "");
            Notificaciones.Uses(this.SharedKernel, "Usa", "");

            Colaboraci�n.Uses(containerDiagram.Database, "Usa", "");
            Colaboraci�n.Uses(this.SharedKernel, "Usa", "");

            Soporte.Uses(containerDiagram.Database, "Usa", "");
            Soporte.Uses(this.SharedKernel, "Usa", "");
            Soporte.Uses(contextDiagram.Tarjetas_Credito_Debito, "Usa", "");
            Soporte.Uses(contextDiagram.Redes_Sociales, "Usa", "");

            Encuestas.Uses(containerDiagram.Database, "Usa", "");
            Encuestas.Uses(this.SharedKernel, "Usa", "");

            Seguimiento.Uses(containerDiagram.Database, "Usa", "");
            Seguimiento.Uses(this.SharedKernel, "Usa", "");

            Promocion.Uses(containerDiagram.DatabaseNoSQL, "Usa", "");
            Promocion.Uses(this.SharedKernel, "Usa", "");
            Promocion.Uses(contextDiagram.Email, "Usa", "");

            Comunicaci�n.Uses(containerDiagram.DatabaseNoSQL, "Usa", "");
            Comunicaci�n.Uses(this.SharedKernel, "Usa", "");

            
        }

        private void ApplyStyles() {
			SetTags();
			Styles styles = c4.ViewSet.Configuration.Styles;
			styles.Add(new ElementStyle(this.componentTag) { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
		}

		private void SetTags()
		{
			Informes.AddTags(this.componentTag);
            Notificaciones.AddTags(this.componentTag);
            Colaboraci�n.AddTags(this.componentTag);
            Soporte.AddTags(this.componentTag);
            Encuestas.AddTags(this.componentTag);
            Seguimiento.AddTags(this.componentTag);
            Promocion.AddTags(this.componentTag);
            Comunicaci�n.AddTags(this.componentTag);
            SharedKernel.AddTags(this.componentTag);
        }

		private void CreateView() {
			string title = "API Rest Component Diagram";
			ComponentView componentView = c4.ViewSet.CreateComponentView(containerDiagram.ApiRest, title, title);
			componentView.Title = title;
			componentView.Add(containerDiagram.Database);
            componentView.Add(containerDiagram.DatabaseNoSQL);
            componentView.Add(contextDiagram.Email);
            componentView.Add(contextDiagram.Redes_Sociales);
			componentView.Add(contextDiagram.Tarjetas_Credito_Debito);
			componentView.AddAllComponents();
		}
	}
}