#ifndef _OPRUNA0_H_
#define _OPRUNA0_H_

#include "il_types.h"
#include "OpCtxDef.h"

//  Description:
//      �������������� ���� �������� �������� ���������� �������� '�������� ������'.<p/>
//		� �������� ���������� �������� ���������� ������������� ������� �� ��������������� ������� ������� ��������.   		
//  See Also:
//  Arguments:
//      p_opContext	 -	��������� �� ���������� ������������� ����� ��������� �������� ���.
//						����� ������� ����������:
//						- �������� ����� ��������� ��������.
//						- ���������������� � ��������� ��� ����������� �������� OperationCode ��������� UEC_OP_PROVIDE_SERVICE. 
//		inout_pEvent -	��������� �� ���������� �� ��������� ������� � �������� ����� �������� ������� �������� (��. 'uec_event.h').
//						����� ������� ��� ���������� ���������� ���������������� ��������� E_ACTIVATE.
//  Return Value:
//      IL_WORD	-	��� �������� ��������� ����������.
//					������� �������� S_IDLE �������� ���������� ������ �������� � ����� �� ����� ��������� ������� �������.
//  Summary:
//      ������������� �������� �������� �������� '�������� ������'. 
IL_FUNC IL_WORD opRunServiceProviderA0(s_opContext *p_opContext, IL_WORD *inout_pEvent);

//  Description:
//      �������������� ���� �������� �������� ���������� ��������.<p/>
//		� �������� ���������� �������� ���������� ������������� ������� �� ��������������� ������� ������� ��������.   		
//  See Also:
//  Arguments:
//      p_opContext	 -	��������� �� ���������� ������������� ����� ��������� �������� ���.
//						����� ������� ����������:
//						- �������� ����� ��������� ��������.
//						- ���������������� � ��������� ��� ����������� �������� OperationCode ����� �� ��������� ��������: UEC_OP_CHANGE_PIN, UEC_OP_UNLOCK_PIN, UEC_OP_CHANGE_PUK, UEC_OP_UNLOCK_PUK. 
//						- ���������������� � ��������� �������� ������ ������ PinNum.
//		inout_pEvent -	��������� �� ���������� �� ��������� ������� � �������� ����� �������� ������� �������� (��. 'uec_event.h').
//						����� ������� ��� ���������� ���������� ���������������� ��������� E_ACTIVATE.
//  Return Value:
//      IL_WORD	-	��� �������� ��������� ����������.
//					������� �������� S_IDLE �������� ���������� ������ �������� � ����� �� ����� ��������� ������� �������.
//  Summary:
//      ������������� �������� �������� ���������� ��������. 
IL_FUNC IL_WORD opRunManagePinPukA0(s_opContext *p_opContext, IL_WORD *inout_Event);

//  Description:
//      �������������� ���� �������� �������� �������������� ������ ����� ���.<p/>
//		� �������� ���������� �������� ���������� ������������� ������� �� ��������������� ������� ������� ��������.   		
//  See Also:
//  Arguments:
//      p_opContext	 -	��������� �� ���������� ������������� ����� ��������� �������� ���.
//						����� ������� ����������:
//						- �������� ����� ��������� ��������.
//						- ���������������� � ��������� ��� ����������� �������� OperationCode ����� �� ��������� ��������: UEC_OP_EDIT_PRIVATE_DATA, UEC_OP_EDIT_OPERATOR_DATA. 
//		inout_pEvent -	��������� �� ���������� �� ��������� ������� � �������� ����� �������� ������� �������� (��. 'uec_event.h').
//						����� ������� ��� ���������� ���������� ���������������� ��������� E_ACTIVATE.
//  Return Value:
//      IL_WORD	-	��� �������� ��������� ����������.
//					������� �������� S_IDLE �������� ���������� ������ �������� � ����� �� ����� ��������� ������� �������.
//  Summary:
//      ������������� �������� �������� �������������� ������ ����� ���. 
IL_FUNC IL_WORD opRunEditCardDataA0 (s_opContext *p_opContext, IL_WORD *inout_Event);

//  Description:
//      �������������� ���� �������� �������� ��������� ���������� ���������.<p/>
//		� �������� ���������� �������� ���������� ������������� ������� �� ��������������� ������� ������� ��������.   		
//  See Also:
//  Arguments:
//      p_opContext	 -	��������� �� ���������� ������������� ����� ��������� �������� ���.
//						����� ������� ����������:
//						- �������� ����� ��������� ��������.
//						- ���������������� � ��������� ��� ����������� �������� OperationCode ��������� UEC_OP_REM_MANAGE_IDAPP_DATA ��� UEC_OP_REM_MANAGE_CARD_DATA. 
//		inout_pEvent -	��������� �� ���������� �� ��������� ������� � �������� ����� �������� ������� �������� (��. 'uec_event.h').
//						����� ������� ��� ���������� ���������� ���������������� ��������� E_ACTIVATE.
//  Return Value:
//      IL_WORD	-	��� �������� ��������� ����������.
//					������� �������� S_IDLE �������� ���������� ������ �������� � ����� �� ����� ��������� ������� �������.
//  Summary:
//      ������������� �������� �������� ��������� ���������� ���������. 
IL_FUNC IL_WORD opRunRemManageDataA0 (s_opContext *p_opContext, IL_WORD *inout_Event);

//  Description:
//      �������������� ���� �������� �������� ���������� �������� ����� ��������� �������� 'sectors.ini'.<p/>
//		� �������� ���������� �������� ���������� ������������� ������� �� ��������������� ������� ������� ��������.   		
//  See Also:
//  Arguments:
//      p_opContext	 -	��������� �� ���������� ������������� ����� ��������� �������� ���.
//						����� ������� ����������:
//						- �������� ����� ��������� ��������.
//						- ���������������� � ��������� ��� ����������� �������� OperationCode ��������� UEC_OP_ADD_SECTOR_EX_DESCR. 
//		inout_pEvent -	��������� �� ���������� �� ��������� ������� � �������� ����� �������� ������� �������� (��. 'uec_event.h').
//						����� ������� ��� ���������� ���������� ���������������� ��������� E_ACTIVATE.
//  Return Value:
//      IL_WORD	-	��� �������� ��������� ����������.
//					������� �������� S_IDLE �������� ���������� ������ �������� � ����� �� ����� ��������� ������� �������.
//  Summary:
//      ������������� �������� �������� ���������� �������� ����� ��������� ��������.
IL_FUNC IL_WORD opRunAddSectorExDescrA0 (s_opContext *p_opContext, IL_WORD *inout_Event);

//  Description:
//      �������������� ���� �������� �������� ���������� ������������ ������� ������������ (���).<p/>
//		� �������� ���������� �������� ���������� ������������� ������� �� ��������������� ������� ������� ��������.   		
//  See Also:
//  Arguments:
//      p_opContext	 -	��������� �� ���������� ������������� ����� ��������� �������� ���.
//						����� ������� ����������:
//						- �������� ����� ��������� ��������.
//						- ���������������� � ��������� ��� ����������� �������� OperationCode ��������� UEC_OP_ADD_SECTOR_EX_DESCR. 
//		inout_pEvent -	��������� �� ���������� �� ��������� ������� � �������� ����� �������� ������� �������� (��. 'uec_event.h').
//						����� ������� ��� ���������� ���������� ���������������� ��������� E_ACTIVATE.
//  Return Value:
//      IL_WORD	-	��� �������� ��������� ����������.
//					������� �������� S_IDLE �������� ���������� ������ �������� � ����� �� ����� ��������� ������� �������.
//  Summary:
//      ������������� �������� �������� ���������� ���.
IL_FUNC IL_WORD opRunManageSeA0 (s_opContext *p_opContext, IL_WORD *inout_Event);

//  Description:
//      �������������� ���� �������� �������� ���������� �������� '����� ������������ �����������'.<p/>
//		� �������� ���������� �������� ���������� ������������� ������� �� ��������������� ������� ������� ��������.   		
//  See Also:
//  Arguments:
//      p_opContext	 -	��������� �� ���������� ������������� ����� ��������� �������� ���.
//						����� ������� ����������:
//						- �������� ����� ��������� ��������.
//						- ���������������� � ��������� ��� ����������� �������� OperationCode ��������� UEC_OP_CHANGE_PASS_PHRASE. 
//		inout_pEvent -	��������� �� ���������� �� ��������� ������� � �������� ����� �������� ������� �������� (��. 'uec_event.h').
//						����� ������� ��� ���������� ���������� ���������������� ��������� E_ACTIVATE.
//  Return Value:
//      IL_WORD	-	��� �������� ��������� ����������.
//					������� �������� S_IDLE �������� ���������� ������ �������� � ����� �� ����� ��������� ������� �������.
//  Summary:
//      ������������� �������� �������� �������� '����� ������������ �����������'.
IL_FUNC IL_WORD opRunChangePassPhraseA0 (s_opContext *p_opContext, IL_WORD *inout_Event);

#endif//_OPRUNA0_H_