// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoCompleteManager.cs" company="������">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The AutoCompleteManager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.business.manager
{
  #region references

  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Linq.Expressions;

  using NHibernate;
  using NHibernate.Criterion;

  using rt.core.model.dto;
  using rt.core.model.dto.enumerations;
  using rt.srz.model.dto;
  using rt.srz.model.srz;

  using StructureMap;

  #endregion

  /// <summary>
  ///   The AutoCompleteManager.
  /// </summary>
  public partial class AutoCompleteManager
  {
    #region Public Methods and Operators

    /// <summary>
    /// ��������� ���������� �� ��� ������ � ���� � ����� �� ������, �����, �����
    /// </summary>
    /// <param name="autoComplete">
    /// The first Middle Name.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/> .
    /// </returns>
    public bool AutoCompleteExists(AutoComplete autoComplete)
    {
      return
        GetBy(
              x =>
              x.Id != autoComplete.Id && x.Name == autoComplete.Name && x.Gender == autoComplete.Gender
              && x.Type == autoComplete.Type).Any();
    }

    /// <summary>
    /// �������� ��������� �� �������� ��� ��� � �������
    /// </summary>
    /// <param name="criteria">
    /// The criteria.
    /// </param>
    /// <returns>
    /// The <see cref="SearchResult{AutoComplete}"/> .
    /// </returns>
    public SearchResult<AutoComplete> GetAutoCompleteByCriteria(SearchAutoCompleteCriteria criteria)
    {
      var session = ObjectFactory.GetInstance<ISessionFactory>().GetCurrentSession();
      AutoComplete ac = null;
      Concept gender = null;
      Concept type = null;
      var query = session.QueryOver(() => ac).JoinAlias(x => x.Gender, () => gender).JoinAlias(x => x.Type, () => type);
      if (!string.IsNullOrEmpty(criteria.Name))
      {
        query.WhereRestrictionOn(x => x.Name).IsInsensitiveLike(criteria.Name, MatchMode.Anywhere);
      }

      var count = query.RowCount();
      var result = new SearchResult<AutoComplete> { Skip = criteria.Skip, Total = count };

      query = AddOrder(criteria, ac, gender, type, query);
      query.Skip(criteria.Skip).Take(criteria.Take);

      result.Rows = query.List();
      return result;
    }

    /// <summary>
    /// ���������� ������ ��������� ��� �����
    /// </summary>
    /// <param name="prefix">
    /// The prefix.
    /// </param>
    /// <returns>
    /// The <see cref="IList{AutoComplete}"/>.
    /// </returns>
    public IList<AutoComplete> GetFirstNameAutoComplete(string prefix)
    {
      var session = ObjectFactory.GetInstance<ISessionFactory>().GetCurrentSession();
      var query =
        session.QueryOver<AutoComplete>()
               .Where(x => x.Type.Id == model.srz.concepts.AutoComplete.FirstName)
               .WhereRestrictionOn(x => x.Name)
               .IsLike(prefix + "%")
               .OrderBy(x => x.Name)
               .Asc;
      return query.List();
    }

    /// <summary>
    /// ���������� ������ ��������� ��� ��������
    /// </summary>
    /// <param name="prefix">
    /// The prefix.
    /// </param>
    /// <param name="nameId">
    /// The name Id.
    /// </param>
    /// <returns>
    /// The <see cref="IList{AutoComplete}"/>.
    /// </returns>
    public IList<AutoComplete> GetMiddleNameAutoComplete(string prefix, Guid nameId)
    {
      var session = ObjectFactory.GetInstance<ISessionFactory>().GetCurrentSession();
      var middleNameQuery =
        session.QueryOver<AutoComplete>()
               .Where(x => x.Type.Id == model.srz.concepts.AutoComplete.MiddleName)
               .WhereRestrictionOn(x => x.Name)
               .IsLike(prefix + "%");

      // ���������� �� �����
      if (nameId != Guid.Empty)
      {
        var fistNameSubqury = QueryOver.Of<AutoComplete>().Where(x => x.Id == nameId).Select(x => x.Gender.Id);
        middleNameQuery.WithSubquery.WhereProperty(x => x.Gender.Id).In(fistNameSubqury);
      }

      return middleNameQuery.OrderBy(x => x.Name).Asc.List();
    }

    #endregion

    #region Methods

    /// <summary>
    /// The add order.
    /// </summary>
    /// <param name="criteria">
    /// The criteria.
    /// </param>
    /// <param name="ac">
    /// The ac.
    /// </param>
    /// <param name="gender">
    /// The gender.
    /// </param>
    /// <param name="type">
    /// The type.
    /// </param>
    /// <param name="query">
    /// The query.
    /// </param>
    /// <returns>
    /// The <see cref="IQueryOver"/> .
    /// </returns>
    private IQueryOver<AutoComplete, AutoComplete> AddOrder(
      SearchAutoCompleteCriteria criteria, 
      AutoComplete ac, 
      Concept gender, 
      Concept type, 
      IQueryOver<AutoComplete, AutoComplete> query)
    {
      // ����������
      if (!string.IsNullOrEmpty(criteria.SortExpression))
      {
        Expression<Func<object>> expression = () => ac.Name;
        switch (criteria.SortExpression)
        {
          case "Name":
            expression = () => ac.Name;
            break;
          case "Gender":
            expression = () => gender.Name;
            break;
          case "Type":
            expression = () => type.Name;
            break;
        }

        query = criteria.SortDirection == SortDirection.Ascending
                  ? query.OrderBy(expression).Asc
                  : query.OrderBy(expression).Desc;
      }

      return query;
    }

    #endregion
  }
}