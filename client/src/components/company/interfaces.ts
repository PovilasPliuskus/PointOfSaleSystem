export interface Company {
  id: string;
  name: string;
}

export interface CompanyDetails {
  code: string;
  establishments: any[];
  companyProducts: any[];
  companyServices: any[];
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
}

export interface UpdateCompanyRequest {
  code: string;
  name: string;
  id: string;
  updateTime: string;
}
