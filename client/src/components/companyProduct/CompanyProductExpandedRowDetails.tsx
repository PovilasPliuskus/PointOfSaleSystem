import { CompanyProductObject } from "../../scripts/interfaces";

interface CompanyProductExpandedRowDetailsProps {
  selectedCompanyProduct: CompanyProductObject;
  onEdit: (companyProductId: string) => void;
  onDelete: (companyProductId: string) => void;
}

const CompanyProductExpandedRowDetails: React.FC<
  CompanyProductExpandedRowDetailsProps
> = ({ selectedCompanyProduct, onDelete, onEdit }) => {
  return (
    <tr>
      <td colSpan={2}>
        <div className="border p-2">
          <p>
            <strong>CompanyProduct Name:</strong> {selectedCompanyProduct.name}
          </p>
          <p>
            <strong>Is Alcoholic Beverage:</strong>{" "}
            {selectedCompanyProduct.alcoholicBeverage}
          </p>
          <p>
            <strong>Receive Time:</strong>{" "}
            {new Date(selectedCompanyProduct.receiveTime).toLocaleString()}
          </p>
          <p>
            <strong>Update Time:</strong>{" "}
            {new Date(selectedCompanyProduct.updateTime).toLocaleString()}
          </p>
          <p>
            <strong>Created By Employee ID: </strong>{" "}
            {selectedCompanyProduct.createdByEmployeeId}
          </p>
          <p>
            <strong>Modified By Employee ID:</strong>{" "}
            {selectedCompanyProduct.modifiedByEmployeeId}
          </p>
          <div className="mt-2">
            <button
              className="btn btn-warning me-2"
              onClick={() => onEdit(selectedCompanyProduct.id)}
            >
              Edit
            </button>
            <button
              className="btn btn-danger"
              onClick={() => onDelete(selectedCompanyProduct.id)}
            >
              Delete
            </button>
          </div>
        </div>
      </td>
    </tr>
  );
};

export default CompanyProductExpandedRowDetails;
