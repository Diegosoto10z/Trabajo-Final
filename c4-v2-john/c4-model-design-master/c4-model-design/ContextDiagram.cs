using Structurizr;

namespace c4_model_design
{
	public class ContextDiagram
	{
		private readonly C4 c4;
		public SoftwareSystem Plataforma_Tu_Voz_Se_Escucha { get; private set; }
		public SoftwareSystem Tarjetas_Credito_Debito { get; private set; }
		public SoftwareSystem Redes_Sociales { get; private set; }
        public SoftwareSystem Email { get; private set; }
        public Person Ciudadano { get; private set; }
		public Person Encargado_Municipal { get; private set; }
        public Person Gobiernos_Locales { get; private set; }
        public Person Medios_De_Comunicacion { get; private set; }

        //public SoftwareSystem SendGrid { get; private set; }

        public ContextDiagram(C4 c4)
		{
			this.c4 = c4;
		}

		public void Generate() {
			AddElements();
			AddRelationships();
			ApplyStyles();
			CreateView();
		}

		private void AddElements() {
			AddPeople();
			AddSoftwareSystems();
		}

		private void AddPeople()
		{
			Ciudadano = c4.Model.AddPerson("Ciudadano", "Usuario que es redidente de un distrito");
			Encargado_Municipal = c4.Model.AddPerson("Encargado_Municipal", "Usuario que se encarga de gestionar un sector municipal");
            Gobiernos_Locales = c4.Model.AddPerson("Gobiernos Locales", "Municipios que pertenecen a Lima Metropolitana");
            Medios_De_Comunicacion = c4.Model.AddPerson("Medios De Comunicacion", "Medios que permitan informar sobre problemas o noticas en Lima");

        }

		private void AddSoftwareSystems()
		{
			Plataforma_Tu_Voz_Se_Escucha = c4.Model.AddSoftwareSystem("Plataforma Tu Voz Se Escucha", "Plataforma que permite la union y comunicacion entre los ciudadnos distritales en Lima Metropolitana y sus respectivos municipios");
			Tarjetas_Credito_Debito = c4.Model.AddSoftwareSystem("Stripe", "Medios de pago disponibles para tramites dentro de la plataforma");
			Redes_Sociales = c4.Model.AddSoftwareSystem("Redes Sociales", "Funcionalidad para poder compartir noticias o informes de la plataforma hacia redes sociales populares");
			Email = c4.Model.AddSoftwareSystem("Email", "Actualización de la situación de los foros y transacciones vía correo electrónico.");
		}

		private void AddRelationships() {
			Ciudadano.Uses(Plataforma_Tu_Voz_Se_Escucha, "Hace uso de");
			Encargado_Municipal.Uses(Plataforma_Tu_Voz_Se_Escucha, "Informa a travez de ");
            Gobiernos_Locales.Uses(Plataforma_Tu_Voz_Se_Escucha, "Conforma");
            Medios_De_Comunicacion.Uses(Plataforma_Tu_Voz_Se_Escucha, "Participa");


            Plataforma_Tu_Voz_Se_Escucha.Uses(Redes_Sociales, "Publicacion de noticias o informes");
			Plataforma_Tu_Voz_Se_Escucha.Uses(Tarjetas_Credito_Debito, "Procesamiento De Pagos");
			Plataforma_Tu_Voz_Se_Escucha.Uses(Email,"Envío de correos electrónicos a los usuarios");
		}

		private void ApplyStyles() {
			SetTags();

			Styles styles = c4.ViewSet.Configuration.Styles;
			
			styles.Add(new ElementStyle(nameof(Ciudadano)) { Background = "#0a60ff", Color = "#ffffff", Shape = Shape.Person });
			styles.Add(new ElementStyle(nameof(Encargado_Municipal)) { Background = "#26cf48", Color = "#ffffff", Shape = Shape.Person });
            styles.Add(new ElementStyle(nameof(Gobiernos_Locales)) { Background = "#FF00FF", Color = "#ffffff", Shape = Shape.Person });
            styles.Add(new ElementStyle(nameof(Medios_De_Comunicacion)) { Background = "#DAA520", Color = "#ffffff", Shape = Shape.Person });

            styles.Add(new ElementStyle(nameof(Plataforma_Tu_Voz_Se_Escucha)) { Background = "#008f39", Color = "#ffffff", Shape = Shape.RoundedBox });
			styles.Add(new ElementStyle(nameof(Tarjetas_Credito_Debito)) { Background = "#90714c", Color = "#ffffff", Shape = Shape.RoundedBox });
			styles.Add(new ElementStyle(nameof(Redes_Sociales)) { Background = "#00BFFF", Color = "#ffffff", Shape = Shape.RoundedBox });
            styles.Add(new ElementStyle(nameof(Email)) { Background = "#8A2BE2", Color = "#ffffff", Shape = Shape.RoundedBox });
        }

		private void SetTags()
		{
			Ciudadano.AddTags(nameof(Ciudadano));
			Encargado_Municipal.AddTags(nameof(Encargado_Municipal));
			Gobiernos_Locales.AddTags(nameof(Gobiernos_Locales));
            Medios_De_Comunicacion.AddTags(nameof(Medios_De_Comunicacion));

            Plataforma_Tu_Voz_Se_Escucha.AddTags(nameof(Plataforma_Tu_Voz_Se_Escucha));
			Tarjetas_Credito_Debito.AddTags(nameof(Tarjetas_Credito_Debito));
			Redes_Sociales.AddTags(nameof(Redes_Sociales));
			Email.AddTags(nameof(Email));
		}

		private void CreateView() {
			SystemContextView contextView = c4.ViewSet.CreateSystemContextView(Plataforma_Tu_Voz_Se_Escucha, "Contexto", "Diagrama de Contexto");
			contextView.AddAllSoftwareSystems();
			contextView.AddAllPeople();
		}
	}
}