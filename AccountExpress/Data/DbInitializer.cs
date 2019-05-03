using AccountExpress.Models;
using AccountExpress.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Customers.Any())
            {
                Customer customer0 = new Customer
                {
                    Name = "Ivo Guilherme",
                    Email = "ivo.guiilherme@gmail.com",
                    DateOfBirth = DateTime.Parse("1993-05-07"),
                    CPF = "117.339.256-43",
                    RG = "MG18513569",
                    CNH = "ABC123456",
                    Phone = "(33) 9 9125-2891",
                    Adress = "Av. Altamirando Colombo Ribeiro",
                    AdressNumber = "517",
                    Complement = "Bloco 10, Apt 201",
                    District = "Floresta",
                    City = "Governador Valadares",
                    State = "Minas Gerais",
                    CEP = "35022-618",
                };
                Customer customer1 = new Customer
                {
                    Name = "Camila Silva",
                    Email = "ivo.guiilherme@gmail.com",
                    DateOfBirth = DateTime.Parse("1995-02-08"),
                    CPF = "123.456.789-10",
                    RG = "MG15206958",
                    CNH = "ABC123456",
                    Phone = "(33) 9 9156-6146",
                    Adress = "Av. Altamirando Colombo Ribeiro",
                    AdressNumber = "517",
                    Complement = "Bloco 10, Apt 201",
                    District = "Floresta",
                    City = "Governador Valadares",
                    State = "Minas Gerais",
                    CEP = "35022-618",
                };
                Customer customer2 = new Customer
                {
                    Name = "Iago Cotta",
                    Email = "iago_marcel@hotmail.com",
                    DateOfBirth = DateTime.Parse("1992-06-12"),
                    CPF = "123.456.789-10",
                    RG = "MG00000000",
                    CNH = "ABC123456",
                    Phone = "(33) 9 9999-9999",
                    Adress = "Rua no Centro",
                    AdressNumber = "13",
                    Complement = "Apt 101",
                    District = "Centro",
                    City = "Governador Valadares",
                    State = "Minas Gerais",
                    CEP = "00000-000",
                };
                Customer customer3 = new Customer
                {
                    Name = "Nathália Barcelos",
                    Email = "nathlalia_barcelos@hotmail.com",
                    DateOfBirth = DateTime.Parse("1990-01-19"),
                    CPF = "123.456.789-10",
                    RG = "MG00000000",
                    CNH = "ABC123456",
                    Phone = "(33) 9 9999-9999",
                    Adress = "Rua São Paulo",
                    AdressNumber = "200",
                    Complement = "Casa",
                    District = "São Paulo",
                    City = "Governador Valadares",
                    State = "Minas Gerais",
                    CEP = "00000-000",
                };
                Customer customer4 = new Customer
                {
                    Name = "Dênis Ferreira",
                    Email = "denis@hotmail.com",
                    DateOfBirth = DateTime.Parse("1998-08-19"),
                    CPF = "123.456.789-10",
                    RG = "MG00000000",
                    CNH = "ABC123456",
                    Phone = "(33) 9 9999-9999",
                    Adress = "Rua Atalaia",
                    AdressNumber = "24",
                    Complement = "Casa",
                    District = "Atalaia",
                    City = "Governador Valadares",
                    State = "Minas Gerais",
                    CEP = "00000-000",
                };
                context.AddRange(customer0, customer1, customer2, customer3, customer4);
                context.SaveChanges();
            }

            if (!context.Vehicles.Any())
            {
                Vehicle vehicle0 = new Vehicle
                {
                    Brands = VehicleBrands.Chevrolet,
                    Model = "Onix 1.4 Advantage SPE/4",
                    Type = VehicleType.Econômico,
                    Doors = VehicleDoors.Quatro,
                    Color = "Branco",
                    Fuel = VehicleFuel.Flex,
                    Exchange = VehicleExchange.Automático,
                    Steering = VehicleSteering.Hidráulica,
                    Manufacturing = VehicleManufacturing.Ano2019,
                    Mileage = "10.000 KM",
                    Plate = "PWK6523",
                    Chassis = "AS5265Ad85SDS256",
                    Observations = "Som, ar condicionado, trava elétrica e alarme"
                };
                Vehicle vehicle1 = new Vehicle
                {
                    Brands = VehicleBrands.Fiat,
                    Model = "Punto 1.4 Attractive 8V",
                    Type = VehicleType.Econômico,
                    Doors = VehicleDoors.Quatro,
                    Color = "Preto",
                    Fuel = VehicleFuel.Flex,
                    Exchange = VehicleExchange.Automático,
                    Steering = VehicleSteering.Hidráulica,
                    Manufacturing = VehicleManufacturing.Ano2018,
                    Mileage = "25.000 KM",
                    Plate = "FRG2587",
                    Chassis = "FEF6659FEFE852CDFAS",
                    Observations = "Ar condicionado, airbags, central multimídia e alarme"
                };
                Vehicle vehicle2 = new Vehicle
                {
                    Brands = VehicleBrands.VolksWagen,
                    Model = "Gol Trendline 1.6 T.Flex 8V",
                    Type = VehicleType.Econômico,
                    Doors = VehicleDoors.Quatro,
                    Color = "Vermelho",
                    Fuel = VehicleFuel.Flex,
                    Exchange = VehicleExchange.Automático,
                    Steering = VehicleSteering.Hidráulica,
                    Manufacturing = VehicleManufacturing.Ano2019,
                    Mileage = "40.000 KM",
                    Plate = "VGT8853",
                    Chassis = "FRT95638HYGT9634",
                    Observations = "Ar condicionado, airbags, central multimídia e alarme"

                };
                Vehicle vehicle3 = new Vehicle
                {
                    Brands = VehicleBrands.BMW,
                    Model = "X1 2.0 16V Turbo ActiveFlex SDrive20I X-Line",
                    Type = VehicleType.Luxo,
                    Doors = VehicleDoors.Quatro,
                    Color = "Cinza Chumbo",
                    Fuel = VehicleFuel.Flex,
                    Exchange = VehicleExchange.DuplaEmbreagem,
                    Steering = VehicleSteering.Elétrica,
                    Manufacturing = VehicleManufacturing.Ano2016,
                    Mileage = "13.000 KM",
                    Plate = "PKW3062",
                    Chassis = "PLOK96528FRG9632",
                    Observations = "Central Multimídia, Ar Cond, Câmera de Ré, Sensor de aproximação lateral, Piloto automático"
                };
                Vehicle vehicle4 = new Vehicle
                {
                    Brands = VehicleBrands.Nissan,
                    Model = "370Z Coupe 3.7 V6",
                    Type = VehicleType.Esportivo,
                    Doors = VehicleDoors.Duas,
                    Color = "Azul",
                    Fuel = VehicleFuel.Gasolina,
                    Exchange = VehicleExchange.DuplaEmbreagem,
                    Steering = VehicleSteering.Elétrica,
                    Manufacturing = VehicleManufacturing.Ano2015,
                    Mileage = "54.000 KM",
                    Plate = "VFG9535",
                    Chassis = "PLOK96528FRG9632",
                    Observations = "Central Multimídia, Ar Cond, Câmera de Ré, Sensor de aproximação lateral, Piloto automático"
                };

                context.AddRange(vehicle0, vehicle1, vehicle2, vehicle3, vehicle4);
                context.SaveChanges();
            }
        }
    }
}