// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBatchManager.cs" company="������">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The interface BatchManager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.business.manager
{
  using System;
  using System.Collections.Generic;

  using rt.core.model.dto;
  using rt.srz.model.dto;
  using rt.srz.model.srz;

  /// <summary>
  ///   The interface BatchManager.
  /// </summary>
  public partial interface IBatchManager
  {
    #region Public Methods and Operators

    /// <summary>
    /// �������� ������ ��� ������ �� �������
    /// </summary>
    /// <param name="periodId">
    /// The period Id.
    /// </param>
    /// <returns>
    /// The <see cref="IList{Batch}"/>.
    /// </returns>
    IList<Batch> GetPfrBatchesByPeriod(Guid periodId);

    /// <summary>
    ///   The get pfr batches by user.
    /// </summary>
    /// <returns>
    ///   The <see cref="IList{Batch}" />.
    /// </returns>
    IList<Batch> GetPfrBatchesByUser();

    /// <summary>
    ///   ���������� ��� ������� �� ������� ���� ������ �� ������ � ����� �������� ���
    /// </summary>
    /// <returns>
    ///   The <see cref="IList{Batch}" />.
    /// </returns>
    IList<Period> GetPfrPeriods();

    /// <summary>
    /// ���������� ���������� �� ���������� ���
    /// </summary>
    /// <param name="batchId">
    /// The batch Id.
    /// </param>
    /// <returns>
    /// The <see cref="PfrStatisticInfo"/> .
    /// </returns>
    PfrStatisticInfo GetPfrStatisticInfoByBatch(Guid batchId);

    /// <summary>
    /// ���������� ���������� �� ���������� ���
    /// </summary>
    /// <param name="periodId">
    /// The period Id.
    /// </param>
    /// <returns>
    /// The <see cref="PfrStatisticInfo"/> .
    /// </returns>
    PfrStatisticInfo GetPfrStatisticInfoByPeriod(Guid periodId);

    /// <summary>
    /// �������� ���� ��� �� �����������
    /// </summary>
    /// <param name="batchId">
    /// The batch Id.
    /// </param>
    void MarkBatchAsUnexported(Guid batchId);

    /// <summary>
    /// ������������ ����� �������� �������� �������� ��������� ��� ���
    /// </summary>
    /// <param name="criteria">
    /// The criteria.
    /// </param>
    /// <returns>
    /// The <see cref="SearchResult{SearchBatchResult}"/>.
    /// </returns>
    SearchResult<SearchBatchResult> SearchExportSmoBatches(SearchExportSmoBatchCriteria criteria);

    #endregion
  }
}