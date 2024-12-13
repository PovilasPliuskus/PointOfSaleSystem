export interface Company {
  id: string;
  name: string;
  code: string;
  receiveTime: Date;
  updateTime: Date;
  createdByEmployee: string;
  updatedByEmployee: string;
  establishments: Establishment[] | null;
  companyProducts: CompanyProduct[] | null;
  companyServices: CompanyService[] | null;
}

export interface FullOrder {
  id: string;
  name: string;
  receiveTime: Date;
  updateTime: Date;
  createdByEmployee: string;
  updatedByEmployee: string;
  orders: Order[];
  tip: number;
  status: number;
}

export interface Order {
  id: string;
  name: string;
  receiveTime: Date;
  updateTime: Date;
  createdByEmployee: string;
  updatedByEmployee: string;
  establishmentProductId: string;
  establishmentServiceId: string;
  count: number;
}

export interface CompanyService {
  id: string;
  name: string;
  receiveTime: Date;
  updateTime: Date;
  createdByEmployee: string;
  updatedByEmployee: string;
}

export interface CompanyProduct {
  id: string;
  name: string;
  receiveTime: Date;
  updateTime: Date;
  createdByEmployee: string;
  updatedByEmployee: string;
  alcoholicBeverage: boolean;
}

export interface Establishment {
  id: string;
  name: string;
  receiveTime: Date;
  updateTime: Date;
  createdByEmployee: string;
  updatedByEmployee: string;
  code: string;
  employees: Employee[] | null;
  establishmentProducts: EstablishmentProduct[] | null;
  establishmentServices: EstablishmentService[] | null;
}

export interface Employee {
  id: string;
  name: string;
  receiveTime: Date;
  updateTime: Date;
  createdByEmployee: string;
  updatedByEmployee: string;
  surname: string;
  salary: number;
  status: number;
  loginUsername: string;
  LoginPasswordHashed: string;
}

export interface EstablishmentProduct {
  id: string;
  name: string;
  receiveTime: Date;
  updateTime: Date;
  createdByEmployee: string;
  updatedByEmployee: string;
  price: number;
  amountInStock: number;
  currency: number;
}

export interface EstablishmentService {
  id: string;
  name: string;
  receiveTime: Date;
  updateTime: Date;
  createdByEmployee: string;
  updatedByEmployee: string;
  price: number;
  currency: number;
}

export interface UpdateCompanyRequest {
  code: string;
  name: string;
  id: string;
  updateTime: string;
}
