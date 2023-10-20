using Structurizr;
using Structurizr.Api;

namespace c4_model_design
{
	public class C4
	{
		private readonly long workspaceId = 86946;
		private readonly string apiKey = "90f04049-2203-4472-93a7-8cffd8c541e2";
		private readonly string apiSecret = "6cb3ed1f-6eae-4f3b-a6d6-dd8a76fca96a";

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