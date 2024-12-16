import { CompanyProductObject } from "../../scripts/interfaces";
import React from "react";
import CompanyProductExpandedRowDetails from "./CompanyProductExpandedRowDetails";

interface CompanyProductTableProps {
  companyProducts: CompanyProductObject[];
  paginatedCompanyProducts: CompanyProductObject[];
  currentPage: number;
  pageSize: number;
  expandedRow: number | null;
  selectedCompanyProduct: CompanyProductObject | null;

  handleRowClick: (index: number, companyProductId: string) => void;
  handleEditClick: (companyProductId: string) => void;
  handleDeleteClick: (companyProductId: string) => void;
}

const CompanyProductTable: React.FC<CompanyProductTableProps> = ({
  companyProducts,
  paginatedCompanyProducts,
  currentPage,
  pageSize,
  expandedRow,
  selectedCompanyProduct,
  handleRowClick,
  handleEditClick,
  handleDeleteClick,
}) => {
  return (
    <table className="table table-striped">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Company Product Name</th>
        </tr>
      </thead>
      <tbody>
        {paginatedCompanyProducts.map((companyProduct, index) => {
          const globalIndex = (currentPage - 1) * pageSize + index;
          return (
            <React.Fragment key={companyProduct.id}>
              <tr
                onClick={() => handleRowClick(globalIndex, companyProduct.id)}
                style={{ cursor: "pointer" }}
              >
                <th scope="row">{globalIndex + 1}</th>
                <td>{companyProduct.name}</td>
              </tr>

              {expandedRow === globalIndex && selectedCompanyProduct && (
                <CompanyProductExpandedRowDetails
                  selectedCompanyProduct={selectedCompanyProduct}
                  onEdit={handleEditClick}
                  onDelete={handleDeleteClick}
                />
              )}
            </React.Fragment>
          );
        })}
      </tbody>
    </table>
  );
};

export default CompanyProductTable;
