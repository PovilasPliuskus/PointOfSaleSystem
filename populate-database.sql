DELETE FROM public."Order";
DELETE FROM public."FullOrder";
DELETE FROM public."EstablishmentService";
DELETE FROM public."EstablishmentProduct";
DELETE FROM public."CompanyService";
DELETE FROM public."CompanyProduct";
DELETE FROM public."Employee";
DELETE FROM public."Establishment";
DELETE FROM public."Company";

INSERT INTO public."Company" ("Id", "Code", "Name", "ReceiveTime", "UpdateTime", "fkCreatedByEmployee", "fkModifiedByEmployee")
VALUES 
    ('9d00daef-27c5-4ac4-a8a5-5d0295ab426c', 'TB', 'Tasty Burgers', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('d9246e3d-fc0f-4137-8513-55b6ccf573b7', 'HA', 'Hotel Amazing', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('d991f03e-e5f1-48ad-9978-f08330af921f', 'BBS', 'Best Beauty Salon', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL);

INSERT INTO public."Establishment" ("Id", "Code", "fkCompanyId", "Name", "ReceiveTime", "UpdateTime", "fkCreatedByEmployee", "fkModifiedByEmployee")
VALUES
    ('d3beb5bf-a20a-43b4-be2b-d185a54104ef', 'TB001', '9d00daef-27c5-4ac4-a8a5-5d0295ab426c', 'Tasty Burgers Chicago', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('c9b7ba93-dfec-4473-bd78-ffc8638324c0', 'TB002', '9d00daef-27c5-4ac4-a8a5-5d0295ab426c', 'Tasty Burgers Los Angeles', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('512a2407-ad26-4264-85fe-da7370f2d4a5', 'TB003', '9d00daef-27c5-4ac4-a8a5-5d0295ab426c', 'Tasty Burgers New York', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('b045ecea-f3bb-4ffb-a4cc-9bcfa08c4957', 'HA001', 'd9246e3d-fc0f-4137-8513-55b6ccf573b7', 'Hotel Amazing Vilnius', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('1a2f198a-dc72-43d3-8ca3-301c1d5adbf4', 'HA002', 'd9246e3d-fc0f-4137-8513-55b6ccf573b7', 'Hotel Amazing Kaunas', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('90a9c4d6-c3d9-4e76-a81e-40f9f752c3b7', 'BBS001', 'd991f03e-e5f1-48ad-9978-f08330af921f', 'Best Beauty Salon Berlin', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('9cfee38e-0229-49f9-85ef-c98441ce721e', 'BBS001', 'd991f03e-e5f1-48ad-9978-f08330af921f', 'Best Beauty Salon Frankfurt', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL);

INSERT INTO public."Employee" ("Id", "Surname", "Salary", "Status", "fkEstablishmentId", "LoginUsername", "LoginPasswordHashed", "Name", "ReceiveTime", "UpdateTime", "fkCreatedByEmployee", "fkModifiedByEmployee")
VALUES
    ('2ed63766-17e8-4d52-9715-aef236f03d62', 'Blevins', '1000.00', '1', 'd3beb5bf-a20a-43b4-be2b-d185a54104ef', 'ColinBlevins', 'None', 'Colin', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('56d7f844-ae96-4978-b356-f274d4e21f64', 'Barton', '2000.00', '3', 'd3beb5bf-a20a-43b4-be2b-d185a54104ef', 'KhadijaBarton', 'None', 'Khadija', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('0e7d011a-e3ab-4c54-9658-8627784fdf31', 'Jennings', '1750.00', '3', '90a9c4d6-c3d9-4e76-a81e-40f9f752c3b7', 'SalmaJennings', 'None', 'Salma', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('6df12961-e946-44b2-9ffc-5d225763b12a', 'Garrett', '1000.00', '2', 'b045ecea-f3bb-4ffb-a4cc-9bcfa08c4957', 'KeeyanGarret', 'None', 'Keeyan', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL);

INSERT INTO public."CompanyProduct" ("Id", "AlcoholicBeverage", "fkCompanyId", "Name", "ReceiveTime", "UpdateTime", "fkCreatedByEmployee", "fkModifiedByEmployee")
VALUES
    ('4d4f1c2f-e69e-4213-8b4c-b4c3826d7bb3', '0', '9d00daef-27c5-4ac4-a8a5-5d0295ab426c', 'Coca-Cola', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('2268c0ee-c7b9-49e0-9ead-6aa641a212b2', '0', '9d00daef-27c5-4ac4-a8a5-5d0295ab426c', 'Chicken Burger', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('cae3d41a-ff10-4273-8f9e-d7ea1bbb40af', '0', '9d00daef-27c5-4ac4-a8a5-5d0295ab426c', 'French Fries', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('6f0c8612-623b-425c-9eb4-7776c39e183c', '0', '9d00daef-27c5-4ac4-a8a5-5d0295ab426c', 'Ketchup', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('be21a510-38d8-4690-bb1e-cbe8ccd493ff', '0', '9d00daef-27c5-4ac4-a8a5-5d0295ab426c', 'Chicken Nuggets', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('df9f251a-90ff-473d-b6a2-f4183ca57cdb', '0', '9d00daef-27c5-4ac4-a8a5-5d0295ab426c', 'Mineral Water', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('39b37ff8-49b1-4169-84a7-82ebbd061267', '0', '9d00daef-27c5-4ac4-a8a5-5d0295ab426c', 'Beef Burger', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('39633ba8-1a5a-403d-b881-cccc3ccaaab9', '0', '9d00daef-27c5-4ac4-a8a5-5d0295ab426c', 'Cheeseburger', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('29fed837-92bf-4bd5-84a4-262b8563c8f6', '0', 'd9246e3d-fc0f-4137-8513-55b6ccf573b7', 'Beef Stake', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('844a3f12-584a-4579-a45e-9c580510b1f3', '0', 'd9246e3d-fc0f-4137-8513-55b6ccf573b7', 'Chicken Wings', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('93793759-8d04-41e4-a2ec-90fbe47b803a', '1', 'd9246e3d-fc0f-4137-8513-55b6ccf573b7', 'German Beer', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('03aed8eb-4dfe-4a2d-89d4-1a8b98377e75', '1', 'd9246e3d-fc0f-4137-8513-55b6ccf573b7', 'Red Wine', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('66ae8376-a90e-421d-a309-a1d53a03dec3', '0', 'd9246e3d-fc0f-4137-8513-55b6ccf573b7', 'Salad', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('2aac2406-c7b3-4173-ae95-a44dc1c1c589', '0', 'd9246e3d-fc0f-4137-8513-55b6ccf573b7', 'Shrimps', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('546e531c-9bab-4076-aeea-d74d8a02f20e', '1', 'd9246e3d-fc0f-4137-8513-55b6ccf573b7', 'Mohito Cocktail', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL);

INSERT INTO public."CompanyService" ("Id", "fkCompanyId", "Name", "ReceiveTime", "UpdateTime", "fkCreatedByEmployee", "fkModifiedByEmployee")
VALUES
    ('dab208bb-c75b-4b5e-aae7-53373a051435', 'd9246e3d-fc0f-4137-8513-55b6ccf573b7', 'Single Bedroom', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('46cfaa2b-7f99-4e33-9739-30947bbbb96d', 'd9246e3d-fc0f-4137-8513-55b6ccf573b7', 'Public Pool', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('c56808c3-e251-4c48-977d-cf35f0f3d7fb', 'd991f03e-e5f1-48ad-9978-f08330af921f', 'Haircut', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('f2a554b9-1821-4504-8472-aa16487fbaae', 'd991f03e-e5f1-48ad-9978-f08330af921f', 'Nail Polish', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL);

INSERT INTO public."EstablishmentProduct" ("Id", "Price", "AmountInStock", "Currency", "fkEstablishmentId", "Name", "ReceiveTime", "UpdateTime", "fkCreatedByEmployee", "fkModifiedByEmployee")
VALUES
    ('07587c33-910c-4241-8219-b68107274fe5', '5.95', '100', '2', 'd3beb5bf-a20a-43b4-be2b-d185a54104ef', 'Coca-Cola', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('dd08f1ad-0af2-4397-b8f4-acca39274b78', '6.95', '105', '2', 'd3beb5bf-a20a-43b4-be2b-d185a54104ef', 'Chicken Burger', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('1336f86d-2c87-4cdd-8dcb-a36f477ebf1a', '7.95', '200', '2', 'd3beb5bf-a20a-43b4-be2b-d185a54104ef', 'French Fries', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('d8e402c5-efa5-4bd9-9b57-4d9f84e39a41', '8.95', '144', '1', '1a2f198a-dc72-43d3-8ca3-301c1d5adbf4', 'Shrimps', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('e393efeb-a58a-423e-b5c2-55d212e9cd02', '9.95', '361', '1', '1a2f198a-dc72-43d3-8ca3-301c1d5adbf4', 'Mohito Cocktail', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL);

INSERT INTO public."EstablishmentService" ("Id", "Price", "Currency", "fkEstablishmentId", "Name", "ReceiveTime", "UpdateTime", "fkCreatedByEmployee", "fkModifiedByEmployee")
VALUES
    ('45f2f79d-28ec-4149-a5d0-30a87f3c6265', '15.14', '1', 'b045ecea-f3bb-4ffb-a4cc-9bcfa08c4957', 'Public Pool', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('ca86f3fe-e4a4-41dc-b602-83f5a025a5a0', '12.99', '1', '9cfee38e-0229-49f9-85ef-c98441ce721e', 'Haircut', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL);

INSERT INTO public."FullOrder" ("Id", "Tip", "Status", "Name", "ReceiveTime", "UpdateTime", "fkCreatedByEmployee", "fkModifiedByEmployee")
VALUES
    ('a53fab32-85b9-4e37-b91d-9d72b3118f55', '10.00', '1', 'Table1', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('250c7f3b-ec47-4416-b075-3d3987ca7d4b', '7.50', '1', 'Table2', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL),
    ('46332d6c-ecfc-4c41-a189-7555adb32bd1', '2.00', '2', 'Table3', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL);

INSERT INTO public."Order" ("Id", "fkEstablishmentProduct", "fkEstablishmentService", "Count", "Name", "ReceiveTime", "UpdateTime", "fkCreatedByEmployee", "fkModifiedByEmployee", "fkFullOrderId")
VALUES
    ('9408ccab-bc42-471e-9018-031022a31c04', '07587c33-910c-4241-8219-b68107274fe5', NULL, 1, 'Coca-Cola', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL, 'a53fab32-85b9-4e37-b91d-9d72b3118f55'),
    ('53103090-6874-4741-ad05-a41fecf6f61b', 'e393efeb-a58a-423e-b5c2-55d212e9cd02', NULL, 2, 'Mohito Cocktail', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL, 'a53fab32-85b9-4e37-b91d-9d72b3118f55'),
    ('6aa095e3-c36a-4dc1-bb67-736e6a4b9170', 'd8e402c5-efa5-4bd9-9b57-4d9f84e39a41', NULL, 3, 'Shrimps', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL, '250c7f3b-ec47-4416-b075-3d3987ca7d4b'),
    ('f3793747-11cd-46a4-b116-b21272e65410', NULL, '45f2f79d-28ec-4149-a5d0-30a87f3c6265', 1, 'Public Pool', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL, '250c7f3b-ec47-4416-b075-3d3987ca7d4b'),
    ('8c42b5b1-803b-4815-adba-78c7f3779b47', NULL, 'ca86f3fe-e4a4-41dc-b602-83f5a025a5a0', 1, 'Fancy Haircut', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL, '46332d6c-ecfc-4c41-a189-7555adb32bd1'),
    ('c8481d10-25a2-47cc-a37e-9062c856d2c3', '1336f86d-2c87-4cdd-8dcb-a36f477ebf1a', NULL, 2, 'French Fries', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, NULL, NULL, '46332d6c-ecfc-4c41-a189-7555adb32bd1');