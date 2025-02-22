resource "azurerm_container_app" "container_app" {
  name                         = "dept-dev-container-app-trans"
  container_app_environment_id = azurerm_container_app_environment.container_app_environment.id
  resource_group_name          = azurerm_resource_group.resource-group-translation.name
  revision_mode                = "Multiple"

  template {
    container {
      name   = "dept-dev-template-container-translation"
      image  = "mcr.microsoft.com/k8se/quickstart:latest"
      cpu    = 0.25
      memory = "0.5Gi"
    }
  }

  # Ingress Configuration
  ingress {
    external_enabled  = true               # Expose the container app externally (publicly accessible)
    target_port   = 8080                   # The port the container app listens on
    allow_insecure_connections = false     # Whether to allow insecure traffic (HTTP). Set to false for HTTPS.

   

    traffic_weight {
      percentage = 100
      label = "primary" 
      latest_revision = true                 
    }

    # Optionally, you can configure a custom hostname (like a subdomain of a domain)
    # fqdn = "mycustomhostname.azurecontainerapps.io"
  }
 
   tags = {
    environment = "Development"  # Example tag: key = "Environment", value = "Development"
    src = var.src_key
  }
}