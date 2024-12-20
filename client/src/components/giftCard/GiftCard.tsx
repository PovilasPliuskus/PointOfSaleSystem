import { useEffect, useState } from "react";
import { CreateGiftCardRequest, FullOrderObject, GiftCardObject, UpdateGiftCardRequest } from "../../scripts/interfaces";
import GiftCardTable from "./GiftCardTable";
import Pagination from "../Pagination";
import {
  AddGiftCard,
  DeleteGiftCard,
  fetchAllGiftCards,
  fetchGiftCard,
  UpdateGiftCard,
} from "../../scripts/giftCardFunctions";
import EditGiftCardModal from "./EditGiftCardModal";
import AddGiftCardModal from "./AddGiftCardModal";
import { v4 as uuidv4 } from "uuid";
import Navbar from "../Navbar";
import { fetchAllFullOrders } from "../../scripts/fullOrderFunctions";

function GiftCard() {
  // Variables
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const [loading, setLoading] = useState(true);
  const [giftcards, setGiftCards] = useState<GiftCardObject[]>([]);
  const [expandedRow, setExpandedRow] = useState<number | null>(null);
  const [selectedGiftCard, setSelectedGiftCard] = useState<GiftCardObject | null>(
    null
  );
  const [fullOrders, setFullOrders] = useState<FullOrderObject[]>([]);

  const paginatedGiftCards = giftcards.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  // Used for Editing GiftCard
  const [showEditModal, setShowEditModal] = useState(false);
  const [newEditGiftCardAmount, setnewEditGiftCardAmount] = useState(0.0);
  const [newEditGiftCardName, setNewEditGiftCardName] = useState("");
  const [newEditGiftCardCurrency, setNewEditGiftCardCurrency] = useState(0);

  // Used for Adding GiftCard
  const [showAddModal, setShowAddModal] = useState(false);
  const [newAddGiftCardAmount, setnewAddGiftCardAmount] = useState(0.0);
  const [newAddGiftCardName, setNewAddGiftCardName] = useState("");
  const [newAddGiftCardCurrency, setNewAddGiftCardCurrency] = useState(0);
  const [newFullOrdersId, setNewFullOrdersId] = useState("");

  // Functions
  const handleRowClick = async (index: number, giftCardId: string) => {
    console.log("Pressed handleRowClick");

    setExpandedRow(expandedRow === index ? null : index);

    if (expandedRow !== index) {
      try {
        const selectedGiftCard = await fetchGiftCard(giftCardId);

        console.log("Fetched selected giftCard details: ", selectedGiftCard);
        setSelectedGiftCard(selectedGiftCard);
      } catch (error) {
        console.error("Error fetching giftCard details:", error);
      }
    }
  };

  const handleEditClick = () => {
    console.log("Pressed handleEditClick");

    if (selectedGiftCard) {
      setShowEditModal(true);
      setNewEditGiftCardName(selectedGiftCard.name);
      setnewEditGiftCardAmount(selectedGiftCard.amount);
      setNewAddGiftCardCurrency(selectedGiftCard.currency);
    }
  };

  const toggleEditGiftCardModal = () => {
    setShowEditModal(!showEditModal);
  };

  const toggleAddGiftCardModal = () => {
    setShowAddModal(!showAddModal);
  };

  const handleEditInputChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value, type } = e.target;
    if (type === "select-one") {
      if (name === "currency") {
        setNewEditGiftCardCurrency(Number(value));
      }
    }
    if (name === "code") setnewEditGiftCardAmount(parseFloat(value));
    if (name === "name") setNewEditGiftCardName(value);
  };

  const handleAddInputChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value, type } = e.target;
    if (type === "select-one") {
      if (name === "currency") {
        setNewAddGiftCardCurrency(Number(value));
      }
    }
    if (name === "code") setnewAddGiftCardAmount(parseFloat(value));
    if (name === "name") setNewAddGiftCardName(value);
    if (name === "fullOrderId") {
      setNewFullOrdersId(value);
      console.log(`VALUE = ${newFullOrdersId}`);
    }
    //if (name === "currency") setNewAddGiftCardCurrency(parseInt(value));
  };

  const handleEditSaveGiftCard = async () => {
    console.log("Pressed Edit Save");
    if (selectedGiftCard) {
      const updatedGiftCard: UpdateGiftCardRequest = {
        id: selectedGiftCard.id,
        amount: newEditGiftCardAmount,
        currency: newEditGiftCardCurrency,
        name: newEditGiftCardName,
        updateTime: new Date().toISOString(),
      };

      const success = await UpdateGiftCard(updatedGiftCard);

      if (!success) {
        alert("Failed to update giftCard");
        return;
      }

      alert("GiftCard updated successfully");

      toggleEditGiftCardModal();
      setExpandedRow(null);
      loadGiftCards();
    }
  };

  const handleAddSaveGiftCard = async () => {
    console.log("Pressed Edit Save");
    const newGiftCard: CreateGiftCardRequest = {
      id: uuidv4(),
      amount: newAddGiftCardAmount,
      name: newAddGiftCardName,
      currency: newAddGiftCardCurrency,
      updateTime: new Date().toISOString(),
      receiveTime: new Date().toISOString(),
      createdByEmployeeId: "00000000-0000-0000-0000-000000000000",
      modifiedByEmployeeId: "00000000-0000-0000-0000-000000000000",
      fkGiftFullOrderId: newFullOrdersId
    };

    console.log("Add GiftCard request body: ", newGiftCard);

    const success = await AddGiftCard(newGiftCard);

    if (!success) {
      alert("Failed to add giftCard");
      return;
    }

    alert("GiftCard added successfully");

    toggleAddGiftCardModal();
    loadGiftCards();
    setnewAddGiftCardAmount(0.0);
    setNewAddGiftCardName("");
    setNewAddGiftCardCurrency(0);
  };

  const handleDeleteClick = async () => {
    console.log("Pressed handleDeleteClick");
    if (selectedGiftCard) {
      const confirmDelete = window.confirm(
        `Are you sure you want to delete ${selectedGiftCard.name}?`
      );

      if (confirmDelete) {
        const success = await DeleteGiftCard(selectedGiftCard.id);

        if (!success) {
          alert("Failed to delete giftCard");
          return;
        }

        alert("GiftCard deleted successfully");

        setExpandedRow(null);
        loadGiftCards();
      }
    }
  };

  const loadGiftCards = async () => {
    try {
      setLoading(true);
      const data = await fetchAllGiftCards();
      console.log("Retrieved from function loadGiftCards: ", data);
      setGiftCards(data);
      const fullOrders = await fetchAllFullOrders();
      setFullOrders(fullOrders);
    } catch (error) {
      console.error("Error loading giftcards: ", error);
    } finally {
      setLoading(false);
    }
  };

  //Calls when component is fully loaded
  useEffect(() => {
    loadGiftCards();
  }, []);

  return (
    <>
      <Navbar />
      <h1 className="text-center mb-4">GiftCards</h1>
      <div className="container mt-4">
        {loading ? (
          <div className="text-center">Loading...</div>
        ) : (
          <GiftCardTable
            giftCards={giftcards}
            paginatedGiftCards={paginatedGiftCards}
            currentPage={currentPage}
            pageSize={pageSize}
            expandedRow={expandedRow}
            selectedGiftCard={selectedGiftCard}
            handleRowClick={handleRowClick}
            handleEditClick={handleEditClick}
            handleDeleteClick={handleDeleteClick}
          />
        )}
        <Pagination
          currentPage={currentPage}
          totalPages={Math.ceil(giftcards.length / pageSize)}
          totalItems={giftcards.length}
          pageSize={pageSize}
          onPageChange={setCurrentPage}
          onPageSizeChange={setPageSize}
        />
        <div className="d-flex justify-content-end mt-3">
          <button
            className="btn btn-success btn-lg"
            onClick={toggleAddGiftCardModal}
          >
            Add GiftCard
          </button>
        </div>
      </div>
      <EditGiftCardModal
        showModal={showEditModal}
        toggleModal={toggleEditGiftCardModal}
        newGiftCardAmount={newEditGiftCardAmount}
        newGiftCardName={newEditGiftCardName}
        newGiftCardCurrency={newEditGiftCardCurrency}
        handleInputChange={handleEditInputChange}
        handleSave={handleEditSaveGiftCard}
      />
      <AddGiftCardModal
        showModal={showAddModal}
        toggleModal={toggleAddGiftCardModal}
        newGiftCardAmount={newAddGiftCardAmount}
        newGiftCardName={newAddGiftCardName}
        newGiftCardCurrency={newAddGiftCardCurrency}
        fullOrders={fullOrders}
        handleInputChange={handleAddInputChange}
        handleSave={handleAddSaveGiftCard}
      />
    </>
  );
}

export default GiftCard;
