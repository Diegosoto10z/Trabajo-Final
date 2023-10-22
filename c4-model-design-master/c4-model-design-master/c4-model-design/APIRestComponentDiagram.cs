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
        public Component Colaboración { get; private set; }
        public Component Soporte { get; private set; }
        public Component Encuestas { get; private set; }
        public Component Evaluacion { get; private set; }
        public Component Seguimiento { get; private set; }
        public Component Promocion { get; private set; }
        public Component Comunicación { get; private set; }

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
            Informes = containerDiagram.ApiRest.AddComponent("Informes de Problemas", "Este módulo permite a los usuarios presentar informes detallados sobre problemas de seguridad y calidad pública en sus áreas locales.", "NodeJS (NestJS)");
            Notificaciones = containerDiagram.ApiRest.AddComponent("Alertas y Notificaciones", "En este módulo se gestionan las alertas y notificaciones enviadas a los usuarios.", "NodeJS (NestJS)");
            Colaboración = containerDiagram.ApiRest.AddComponent("Colaboración Comunitaria", "Este módulo proporciona un espacio para la comunicación y colaboración entre los miembros de la comunidad.", "NodeJS (NestJS)");
            Soporte = containerDiagram.ApiRest.AddComponent("Soporte y Asistencia", "Ofrece soporte técnico y asistencia a los usuarios que tengan preguntas o problemas con la plataforma.", "NodeJS (NestJS)");
            Encuestas = containerDiagram.ApiRest.AddComponent("Encuestas y Retroalimentación", ": Este módulo permite a la comunidad realizar encuestas y proporcionar retroalimentación sobre proyectos y servicios locales, lo que guía la toma de decisiones.", "NodeJS (NestJS)");
            Evaluacion = containerDiagram.ApiRest.AddComponent("Evaluación de Servicios Públicos", ": Los usuarios pueden evaluar y comentar sobre servicios públicos locales, como transporte público y recolección de basura, para impulsar mejoras.", "NodeJS (NestJS)");
            Seguimiento = containerDiagram.ApiRest.AddComponent("Seguimiento de Medios de Comunicación", "Permite a los usuarios hacer un seguimiento de noticias locales y eventos relevantes en los medios de comunicación, lo que facilita la comprensión de la comunidad sobre temas actuales.", "NodeJS (NestJS)");
            Promocion = containerDiagram.ApiRest.AddComponent("Promoción de Eventos Culturales", "Permite a los organizadores de eventos locales promocionar sus actividades culturales, lo que enriquece la vida cultural de la comunidad.", "NodeJS (NestJS)");
            Comunicación = containerDiagram.ApiRest.AddComponent("Comunicación de Eventos Deportivos", ": Permite a los organizadores de eventos deportivos locales comunicar horarios, resultados y detalles importantes a la comunidad deportiva.", "NodeJS (NestJS)");

        }

		private void AddRelationships() {
			Informes.Uses(containerDiagram.Database, "Usa", "");
			Informes.Uses(this.SharedKernel, "Usa", "");

            Notificaciones.Uses(containerDiagram.Database, "Usa", "");
            Notificaciones.Uses(this.SharedKernel, "Usa", "");

            Colaboración.Uses(containerDiagram.Database, "Usa", "");
            Colaboración.Uses(this.SharedKernel, "Usa", "");

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

            Comunicación.Uses(containerDiagram.DatabaseNoSQL, "Usa", "");
            Comunicación.Uses(this.SharedKernel, "Usa", "");

            
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
            Colaboración.AddTags(this.componentTag);
            Soporte.AddTags(this.componentTag);
            Encuestas.AddTags(this.componentTag);
            Seguimiento.AddTags(this.componentTag);
            Promocion.AddTags(this.componentTag);
            Comunicación.AddTags(this.componentTag);
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
