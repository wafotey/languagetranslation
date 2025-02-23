resource "azurerm_container_registry" "container-registry-translation" {
  name                = "deptDevAcrTranslation"  
  resource_group_name = azurerm_resource_group.resource-group-translation.name
  location            = azurerm_resource_group.resource-group-translation.location
  sku                  = "Standard"           # Set the SKU to Standard

  admin_enabled = true  # Enable admin user for registry access
  
  tags = {
    environment = "Development"  # Example tag: key = "Environment", value = "Development"
    src = var.src_key
  }
}