import React from "react";
import { EstablishmentProductObject } from "../../scripts/interfaces";
import EstablishmentProductExpandedRowDetails from "./EstablishmentProductExpandedRowDetails";

interface EstablishmentProductTableProps {
  establishmentProducts: EstablishmentProductObject[];
  paginatedEstablishmentProducts: EstablishmentProductObject[];
  currentPage: number;
  pageSize: number;
  expandedRow: number | null;
  selectedEstablishmentProduct: EstablishmentProductObject | null;

  handleRowClick: (index: number, companyId: string) => void;
  handleEditClick: (companyId: string) => void;
  handleDeleteClick: (companyId: string) => void;
}

const EstablishmentProductTable: React.FC<EstablishmentProductTableProps> = ({
  establishmentProducts,
  paginatedEstablishmentProducts,
  currentPage,
  pageSize,
  expandedRow,
  selectedEstablishmentProduct,

  handleRowClick,
  handleEditClick,
  handleDeleteClick,
}) => {
  return (
    <table className="table table-striped">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Establishment Product Name</th>
        </tr>
      </thead>
      <tbody>
        {paginatedEstablishmentProducts.map((establishmentProduct, index) => {
          const globalIndex = (currentPage - 1) * pageSize + index;
          return (
            <React.Fragment key={establishmentProduct.id}>
              <tr
                onClick={() =>
                  handleRowClick(globalIndex, establishmentProduct.id)
                }
                style={{ cursor: "pointer" }}
              >
                <th scope="row">{globalIndex + 1}</th>
                <td>{establishmentProduct.name}</td>
              </tr>

              {expandedRow === globalIndex && selectedEstablishmentProduct && (
                <EstablishmentProductExpandedRowDetails
                  selectedEstablishmentProduct={selectedEstablishmentProduct}
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

export default EstablishmentProductTable;
