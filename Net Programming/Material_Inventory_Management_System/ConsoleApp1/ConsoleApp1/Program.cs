using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Material
{
    public int MaterialNumber { get; set; }
    public string MaterialName { get; set; }
    public string Specification { get; set; }
    public string Type { get; set; }
    public string MeasurementUnit { get; set; }
}

class InboundMaterial
{
    public int MaterialNumber { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public string SupplierName { get; set; }
}

class OutboundMaterial
{
    public int MaterialNumber { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public string CustomerName { get; set; }
}

class MaterialInventoryManagementSystem
{
    static List<Material> materials = new List<Material>();
    static List<InboundMaterial> inboundMaterials = new List<InboundMaterial>();
    static List<OutboundMaterial> outboundMaterials = new List<OutboundMaterial>();

    static void Main(string[] args)
    {
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("-----Welcome to Material Inventory Management System-----");
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("---------------------------------------------------------");

        while (true)
        {
            Console.WriteLine("1. Input basic information about materials");
            Console.WriteLine("2. Query and modify basic material information");
            Console.WriteLine("3. Input inbound material information");
            Console.WriteLine("4. Query and modify inbound material information");
            Console.WriteLine("5. Input outbound material information");
            Console.WriteLine("6. Query and modify outbound material information");
            Console.WriteLine("7. Query material balance information");
            Console.WriteLine("8. Browse material balance information");
            Console.WriteLine("9. Exit");

            string input = Console.ReadLine();
            int option;
            if (int.TryParse(input, out option))
            {
                switch (option)
                {
                    case 1:
                        InputBasicMaterial();
                        break;
                    case 2:
                        QueryAndModifyBasicMaterial();
                        break;
                    case 3:
                        InputInboundMaterial();
                        break;
                    case 4:
                        QueryAndModifyInboundMaterial();
                        break;
                    case 5:
                        InputOutboundMaterial();
                        break;
                    case 6:
                        QueryAndModifyOutboundMaterial();
                        break;
                    case 7:
                        QueryMaterialBalance();
                        break;
                    case 8:
                        BrowseMaterialBalance();
                        break;
                    case 9:
                        Exit();
                        return;
                    default:
                        Console.WriteLine("Invalid option selected.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void InputBasicMaterial()
    {
        Console.WriteLine("Enter Material Number:");
        int materialNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Material Name:");
        string materialName = Console.ReadLine();
        Console.WriteLine("Enter Specification:");
        string specification = Console.ReadLine();
        Console.WriteLine("Enter Type:");
        string type = Console.ReadLine();
        Console.WriteLine("Enter Measurement Unit:");
        string measurementUnit = Console.ReadLine();

        Material material = new Material()
        {
            MaterialNumber = materialNumber,
            MaterialName = materialName,
            Specification = specification,
            Type = type,
            MeasurementUnit = measurementUnit
        };

        materials.Add(material);

        Console.WriteLine("Material added successfully");
    }

    static void QueryAndModifyBasicMaterial()
    {
        Console.WriteLine("Enter Material Name:");
        string searchKey = Console.ReadLine();

        Material material = materials.Find(m => m.MaterialNumber.ToString() == searchKey || m.MaterialName == searchKey);

        if (material == null)
        {
            Console.WriteLine("Material not found");
        }
        else
        {
            Console.WriteLine($"Material Number: {material.MaterialNumber}");
            Console.WriteLine($"Material Name: {material.MaterialName}");
            Console.WriteLine($"Specification: {material.Specification}");
            Console.WriteLine($"Type: {material.Type}");
            Console.WriteLine($"Measurement Unit: {material.MeasurementUnit}");
            Console.WriteLine("Do you want to modify the material information? (Y/N)");
            string modify = Console.ReadLine();

            if (modify.ToUpper() == "Y")
            {
                Console.WriteLine("Enter new Material Name:");
                string materialName = Console.ReadLine();
                Console.WriteLine("Enter new Specification:");
                string specification = Console.ReadLine();
                Console.WriteLine("Enter new Type:");
                string type = Console.ReadLine();
                Console.WriteLine("Enter new Measurement Unit:");
                string measurementUnit = Console.ReadLine();

                material.MaterialName = materialName;
                material.Specification = specification;
                material.Type = type;
                material.MeasurementUnit = measurementUnit;

                Console.WriteLine("Material information updated successfully");
            }
        }
    }

    static void InputInboundMaterial()
    {
        Console.WriteLine("Enter Material Number:");
        int materialNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Quantity:");
        int quantity = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Date (yyyy-MM-dd):");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Enter Supplier Name:");
        string supplierName = Console.ReadLine();

        InboundMaterial inboundMaterial = new InboundMaterial()
        {
            MaterialNumber = materialNumber,
            Quantity = quantity,
            Date = date,
            SupplierName = supplierName
        };

        inboundMaterials.Add(inboundMaterial);

        Console.WriteLine("Inbound material added successfully");
    }

    static void QueryAndModifyInboundMaterial()
    {
        Console.WriteLine("Enter Material Number:");
        int materialNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Date (yyyy-MM-dd):");
        DateTime date = DateTime.Parse(Console.ReadLine());

        InboundMaterial inboundMaterial = inboundMaterials.Find(im => im.MaterialNumber == materialNumber && im.Date == date);

        if (inboundMaterial == null)
        {
            Console.WriteLine("Inbound material not found");
        }
        else
        {
            Console.WriteLine($"Material Number: {inboundMaterial.MaterialNumber}");
            Console.WriteLine($"Quantity: {inboundMaterial.Quantity}");
            Console.WriteLine($"Date: {inboundMaterial.Date:yyyy-MM-dd}");
            Console.WriteLine($"Supplier Name: {inboundMaterial.SupplierName}");
            Console.WriteLine("Do you want to modify the inbound material information? (Y/N)");
            string modify = Console.ReadLine();

            if (modify.ToUpper() == "Y")
            {
                Console.WriteLine("Enter new Quantity:");
                int quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new Date (yyyy-MM-dd):");
                DateTime newDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter new Supplier Name:");
                string supplierName = Console.ReadLine();

                inboundMaterial.Quantity = quantity;
                inboundMaterial.Date = newDate;
                inboundMaterial.SupplierName = supplierName;

                Console.WriteLine("Inbound material information updated successfully");
            }
        }
    }

    static void InputOutboundMaterial()
    {
        Console.WriteLine("Enter Material Number:");
        int materialNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Quantity:");
        int quantity = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Date (yyyy-MM-dd):");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Enter Customer Name:");
        string customerName = Console.ReadLine();

        OutboundMaterial outboundMaterial = new OutboundMaterial()
        {
            MaterialNumber = materialNumber,
            Quantity = quantity,
            Date = date,
            CustomerName = customerName
        };

        outboundMaterials.Add(outboundMaterial);

        Console.WriteLine("Outbound material added successfully");
    }

    static void QueryAndModifyOutboundMaterial()
    {
        Console.WriteLine("Enter Material Number:");
        int materialNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Date (yyyy-MM-dd):");
        DateTime date = DateTime.Parse(Console.ReadLine());

        OutboundMaterial outboundMaterial = outboundMaterials.Find(om => om.MaterialNumber == materialNumber && om.Date == date);

        if (outboundMaterial == null)
        {
            Console.WriteLine("Outbound material not found");
        }
        else
        {
            Console.WriteLine($"Material Number: {outboundMaterial.MaterialNumber}");
            Console.WriteLine($"Quantity: {outboundMaterial.Quantity}");
            Console.WriteLine($"Date: {outboundMaterial.Date:yyyy-MM-dd}");
            Console.WriteLine($"Customer Name: {outboundMaterial.CustomerName}");
            Console.WriteLine("Do you want to modify the outbound material information? (Y/N)");
            string modify = Console.ReadLine();

            if (modify.ToUpper() == "Y")
            {
                Console.WriteLine("Enter new Quantity:");
                int quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new Date (yyyy-MM-dd):");
                DateTime newDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter new Customer Name:");
                string customerName = Console.ReadLine();

                outboundMaterial.Quantity = quantity;
                outboundMaterial.Date = newDate;
                outboundMaterial.CustomerName = customerName;

                Console.WriteLine("Outbound material information updated successfully");
            }
        }
    }

    static void QueryMaterialBalance()
    {
        Console.WriteLine("Enter Material Number:");
        int materialNumber = int.Parse(Console.ReadLine());

        Material material = materials.Find(m => m.MaterialNumber == materialNumber);

        if (material == null)
        {
            Console.WriteLine("Material not found");
        }
        else
        {
            int inboundQuantity = inboundMaterials.Where(im => im.MaterialNumber == materialNumber).Sum(im => im.Quantity);
            int outboundQuantity = outboundMaterials.Where(om => om.MaterialNumber == materialNumber).Sum(om => om.Quantity);
            int balance = inboundQuantity - outboundQuantity;

            Console.WriteLine($"Material Number: {material.MaterialNumber}");
            Console.WriteLine($"Material Name: {material.MaterialName}");
            Console.WriteLine($"Measurement Unit: {material.MeasurementUnit}");
            Console.WriteLine($"Inbound Quantity: {inboundQuantity}");
            Console.WriteLine($"Outbound Quantity: {outboundQuantity}");
            Console.WriteLine($"Balance: {balance}");
        }
    }

    static void BrowseMaterialBalance()
    {
        Console.WriteLine("Material Balance:");

        foreach (Material material in materials)
        {
            int inboundQuantity = 0;
            int outboundQuantity = 0;

            foreach (InboundMaterial inbound in inboundMaterials)
            {
                if (inbound.MaterialNumber == material.MaterialNumber)
                {
                    inboundQuantity += inbound.Quantity;
                }
            }

            foreach (OutboundMaterial outbound in outboundMaterials)
            {
                if (outbound.MaterialNumber == material.MaterialNumber)
                {
                    outboundQuantity += outbound.Quantity;
                }
            }

            int balance = inboundQuantity - outboundQuantity;

            Console.WriteLine($"Material: {material.MaterialName}, Balance: {balance}");
        }
    }

    static void Exit()
    {
        Console.WriteLine();
    }
}
