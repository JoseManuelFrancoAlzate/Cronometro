import {useState} from "react";
import styled from './Modal.module.css';

const Modal = ({show, handleClose, children})=>{
    if(!show){
        return null;
    }

    return(
        <div  className={styled.modalBackdrop} onClick={handleClose}>
          <div className={styled.modalContent} onClick={(e)=> e.stopPropagation()}>
            <button className={styled.closeButton} onClick={handleClose}>
                &times;
            </button>
            <div className={styled.modalBody}>
{children}
            </div>
          </div> 
        </div>
    )
}


export default Modal