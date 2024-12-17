// Company
export interface CompanyObject {
  id: string;
  name: string;
  code: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  establishments: EstablishmentObject[] | null;
  companyProducts: CompanyProductObject[] | null;
  companyServices: CompanyServiceObject[] | null;
}

export interface TaxObject {
  id: string;
  name: string,
  amount: number,
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
}

export interface UpdateCompanyRequest {
  id: string;
  code: string;
  name: string;
  updateTime: string;
}

export interface UpdateTaxRequest {
  id: string;
  amount: number,
  name: string,
  updateTime: string;
}

// FullOrder
export interface FullOrderObject {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  orders: OrderObject[];
  tip: number;
  status: number;
  currency: number;
  totalPrice: number;
}

export interface CreateFullOrderRequest {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  orders: OrderObject[];
  tip: number;
  status: number;
}

export interface UpdateFullOrderRequest {
  id: string;
  tip: number;
  status: number;
  name: string;
  updateTime: string;
}

// Order
export interface OrderObject {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  establishmentProductId: string;
  establishmentServiceId: string;
  count: number;
  fullOrderId: string;
}

export interface CreateOrderRequest {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  establishmentProductId: string | null;
  establishmentServiceId: string | null;
  count: number;
  fkFullOrderId: string;
}

export interface UpdateOrderRequest {
  id: string;
  name: string;
  count: number;
  updateTime: string;
}

// CompanyService
export interface CompanyServiceObject {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
}

export interface UpdateCompanyServiceRequest {
  id: string;
  name: string;
  updateTime: string;
}

export interface CreateCompanyServiceRequest {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  fkCompanyId: string;
}

// CompanyProduct
export interface CompanyProductObject {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  alcoholicBeverage: boolean;
}

export interface UpdateCompanyProductRequest {
  id: string;
  name: string;
  alcoholicBeverage: boolean;
  updateTime: string;
}

export interface CreateCompanyProductRequest {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  alcoholicBeverage: boolean;
  fkCompanyId: string;
}

// Establishment
export interface EstablishmentObject {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  code: string;
  employees: EmployeeObject[] | null;
  establishmentProducts: EstablishmentProductObject[] | null;
  establishmentServices: EstablishmentServiceObject[] | null;
}

export interface CreateEstablishmentRequest {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  code: string;
  employees: EmployeeObject[] | null;
  establishmentProducts: EstablishmentProductObject[] | null;
  establishmentServices: EstablishmentServiceObject[] | null;
  fkCompanyId: string;
}

export interface UpdateEstablishmentRequest {
  id: string;
  code: string;
  name: string;
  updateTime: string;
}

// Employee
export interface EmployeeObject {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  surname: string;
  salary: number;
  status: number;
  loginUsername: string;
  loginPasswordHashed: string;
}

export interface UpdateEmployeeRequest {
  id: string;
  name: string;
  surname: string;
  salary: number;
  status: number;
  loginUsername: string;
  loginPasswordHashed: string;
  updateTime: string;
}

export interface CreateEmployeeRequest {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  surname: string;
  salary: number;
  status: number;
  loginUsername: string;
  loginPasswordHashed: string;
  fkEstablishmentId: string;
}

// EstablishmentProduct
export interface EstablishmentProductObject {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  price: number;
  amountInStock: number;
  currency: number;
  orders: OrderObject[] | null;
}

export interface CreateEstablishmentProductRequest {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  price: number;
  amountInStock: number;
  currency: number;
  orders: OrderObject[] | null;
  fkEstablishmentId: string;
}

export interface UpdateEstablishmentProductRequest {
  id: string;
  name: string;
  price: number;
  amountInStock: number;
  currency: number;
  updateTime: string;
}

// EstablishmentService
export interface EstablishmentServiceObject {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  price: number;
  currency: number;
  orders: OrderObject[] | null;
}

export interface UpdateEstablishmentServiceRequest {
  id: string;
  name: string;
  price: number;
  currency: number;
  updateTime: string;
}

export interface CreateEstablishmentServiceRequest {
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
  price: number;
  currency: number;
  orders: OrderObject[] | null;
  fkEstablishmentId: string;
}
