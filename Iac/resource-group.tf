resource "azurerm_resource_group" "resource-group-translation" {
  name     = "dept-dev-resource-group-translation"
  location = "Central US"

   tags = {
    environment = "Development"  # Example tag: key = "Environment", value = "Development"
    src = var.src_key
  }
}