using Structurizr;
using Structurizr.Api;

namespace c4_model_design
{
	public class C4
	{
		private readonly long workspaceId = 87044;
		private readonly string apiKey = "c72961ab-f7ac-49d5-9e48-77fd0cd760a9";
		private readonly string apiSecret = "fc3d0fca-82cc-4fd3-a4fd-41f125ab61fa";

		public StructurizrClient StructurizrClient { get; }
		public Workspace Workspace { get; }
		public Model Model { get; }
		public ViewSet ViewSet { get; }

		public C4()
		{
			string workspaceName = "Software Design & Patterns - C4 Model - Sistema de Monitoreo";
			string workspaceDescription = "Sistema de Monitoreo del Traslado Aéreo de Vacunas SARS-CoV-2";
			StructurizrClient = new StructurizrClient(apiKey, apiSecret);
			Workspace = new Workspace(workspaceName, workspaceDescription);
			Model = Workspace.Model;
			ViewSet = Workspace.Views;
		}

		public void Generate() {
			ContextDiagram contextDiagram = new ContextDiagram(this);
			ContainerDiagram containerDiagram = new ContainerDiagram(this, contextDiagram);
            
			APIRestComponentDiagram apiRestComponentDiagram = new APIRestComponentDiagram(this, contextDiagram, containerDiagram);
			
			MonitoringComponentDiagram monitoringComponentDiagram = new MonitoringComponentDiagram(this, contextDiagram, containerDiagram);
            SecurityBCComponentDiagram securityComponentDiagram = new SecurityBCComponentDiagram(this, containerDiagram);
            FlightsBCComponentDiagram flightPlanningComponentDiagram = new FlightsBCComponentDiagram(this, containerDiagram);
            AirportsBCComponentDiagram airportComponentDiagram = new AirportsBCComponentDiagram(this, containerDiagram);
            AircraftsBCComponentDiagram aircraftInventoryComponentDiagram = new AircraftsBCComponentDiagram(this, containerDiagram);
            VaccinesBCComponentDiagram vaccinesInventoryComponentDiagram = new VaccinesBCComponentDiagram(this, containerDiagram);
			
			contextDiagram.Generate();
			containerDiagram.Generate();
			apiRestComponentDiagram.Generate();
            monitoringComponentDiagram.Generate();
			securityComponentDiagram.Generate();
            flightPlanningComponentDiagram.Generate();
			airportComponentDiagram.Generate();
            aircraftInventoryComponentDiagram.Generate();
            vaccinesInventoryComponentDiagram.Generate();
			StructurizrClient.PutWorkspace(workspaceId, Workspace);
		}
	}
}